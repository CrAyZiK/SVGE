using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVectorGraphicsEditor
{
    public class Manipulator : Figure
    {
        private readonly List<Marker> SizeMarkers = new List<Marker>();
        private Group source;
        private FigureInteractionMod fim;
        private Marker selectedMarker;

        public ObservableCollection<Figure> Source => source.Figures;
        public Marker SelectedMarker { get => selectedMarker; }

        public Manipulator()
        {
            Init();
        }

        public void Init() {
            source = new Group();
        }
        public int Count { get => Source.Count; }
        public Group Group { get => source; }

        public override void Offset(PointF p) {
            source.Offset(p);
        }
        public void Add(Figure f) {
            source.Add(f);
            UpdateMarkers();
        }
        public void Remove(Figure f) {
            source.Remove(f);
            UpdateMarkers();
        }
        public void Clear() {
            source.Clear();
            UpdateMarkers();
        }
        public bool Contains(Figure f) {
            return source.Contains(f);  
        }
        public void Drag(PointF offset) {
            //var oldrect = CalcFocusRect(PointF.Empty, selectedMarker is ISizeMarker ? selectedMarker : null);
            //var newrect = CalcFocusRect(offset, selectedMarker is ISizeMarker ? selectedMarker : null);
            var oldrect = source.Bounds;
            var newrect = CalcFocusRect(offset, selectedMarker);
            switch (fim) {
                case FigureInteractionMod.Dragging:
                    source.UpdateLocation(offset, oldrect, newrect);
                    UpdateMarkers();
                    break;
                case FigureInteractionMod.Resizing:
                case FigureInteractionMod.VertexEditing:
                    source.UpdateSize(offset, oldrect, newrect, selectedMarker);
                    UpdateMarkers();
                    break;
                default:
                    return;
            }
        }
        public bool Touch2(PointF point) {
            return source.PointInFigure(point);
        }
        public bool Touch(PointF point, bool nodeChanging) {
            if (source == null) {
                selectedMarker = null;
                fim = FigureInteractionMod.None;
                return false;
            }
            selectedMarker = MarkerSelected(point, nodeChanging);
            if (selectedMarker != null) {
                if (nodeChanging)
                {
                    fim = FigureInteractionMod.VertexEditing;
                    return true;
                }
                else
                {
                    fim = FigureInteractionMod.Resizing;
                    return true;
                }
            }
            if (source.PointInFigure(point)) {
                fim = FigureInteractionMod.Dragging;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Поиск номера маркера в разных режимах редактора
        /// </summary>
        /// <param name="pt">точка "нажатия" мышки</param>
        /// <param name="nodeChanging"></param>
        /// <returns>индекс маркера</returns>
        public virtual Marker MarkerSelected(PointF pt, bool nodeChanging)
        {
            if (nodeChanging)
            {
                if (source is IVertexSupport)
                {
                    // в режиме изменения узлов
                    foreach (var marker in source.VertexMarkers)
                    {
                        marker.UpdateLocation();
                        if (marker.IsInsidePoint(Point.Ceiling(pt)))
                            return marker;
                    }
                }
            }
            else
            {
                // в режиме изменения размеров или перемещения
                foreach (var marker in SizeMarkers)
                {
                    marker.UpdateLocation();
                    if (marker.IsInsidePoint(Point.Ceiling(pt)))
                        return marker;
                }
            }
            return null;
        }

        public void UpdateMarkers()
        {
            SizeMarkers.Clear();
            if (source.Count>0)
            {
                SizeMarkers.AddRange(CreateSizeMarkers());
                foreach (var marker in SizeMarkers)
                    marker.UpdateLocation();
                //if (figure == null) return;
                if (source is IVertexSupport)
                {
                    var figure = source as IVertexSupport;
                    source.VertexMarkers.Clear();
                    source.VertexMarkers.AddRange(figure.CreateVertexMarkers());
                    foreach (var marker in source.VertexMarkers)
                        marker.UpdateLocation();
                }
                else { return; }
            }
        }

        /// <summary>
        /// Метод для рисования контуров перетаскиваемых фигур
        /// </summary>
        /// <param name="graphics">канва для рисования</param>
        /// <param name="offset">смещение фигуры относительно её текущего положения</param>
        /// <param name="marker">индекс маркера</param>
        public void DrawFocusFigure(Graphics graphics, PointF offset, Marker marker)
        {
            //var oldrect = CalcFocusRect(PointF.Empty, selectedMarker is ISizeMarker ? selectedMarker : null);
            //var newrect = CalcFocusRect(offset, selectedMarker is ISizeMarker ? selectedMarker : null);
            var oldrect = source.Bounds;
            var newrect = CalcFocusRect(offset, selectedMarker);
            source.DrawFocusFigure(graphics, offset, oldrect, newrect, selectedMarker);
        }

        /// <summary>
        /// Расчёт нового размерного прямоугольника, с учётом новой точки смещения и индекса маркера
        /// </summary>
        /// <param name="offset">смещение относительно точки нажатия</param>
        /// <param name="marker">индекс маркера</param>
        /// <returns>Новый расчётный прямоугольник</returns>
        public virtual RectangleF CalcFocusRect(PointF offset, Marker marker)
        {
            var rect = source.Bounds;
            var dx = offset.X;
            var dy = offset.Y;
            var dw = dx;
            var dh = dy;
            if (marker == null)
            {
                // перемещение фигуры
                rect.X += dx;
                rect.Y += dy;
            }
            else if (marker is TopLeftSizeMarker)
            {
                // влево-вверх
                if ((rect.Height - dh > 0) && (rect.Width - dw > 0))
                {
                    rect.Width -= dw;
                    rect.Height -= dh;
                    rect.X += dx;
                    rect.Y += dy;
                }
            }
            else if (marker is TopMiddleSizeMarker)
            {
                // вверх
                if (rect.Height - dh > 0)
                {
                    rect.Height -= dh;
                    rect.Y += dy;
                }
            }
            else if (marker is TopRightSizeMarker)
            {
                // вправо-вверх
                if ((rect.Height - dh > 0) && (rect.Width + dw > 0))
                {
                    rect.Width += dw;
                    rect.Height -= dh;
                    rect.Y += dy;
                }
            }
            else if (marker is MiddleRightSizeMarker)
            {
                // вправо
                if (rect.Width + dw > 0)
                {
                    rect.Width += dw;
                }
            }
            else if (marker is BottomRightSizeMarker)
            {
                // вправо-вниз
                if ((rect.Width + dw > 0) && (rect.Height + dh > 0))
                {
                    rect.Width += dw;
                    rect.Height += dh;
                }
            }
            else if (marker is BottomMiddleSizeMarker)
            {
                // вниз
                if (rect.Height + dh > 0)
                {
                    rect.Height += dh;
                }
            }
            else if (marker is BottomLeftSizeMarker)
            {
                // влево-вниз
                if ((rect.Height + dh > 0) && (rect.Width - dw > 0))
                {
                    rect.Width -= dw;
                    rect.Height += dh;
                    rect.X += dx;
                }
            }
            else if (marker is MiddleLeftSizeMarker)
            {
                // влево
                if (rect.Width - dw > 0)
                {
                    rect.Width -= dw;
                    rect.X += dx;
                }
            }
            return rect;
        }
        public override void Draw(Graphics graphics)
        {
            throw new NotImplementedException();
        }

        public List<Marker> CreateSizeMarkers()
        {
            var markers = new List<Marker>
                {
                    new TopLeftSizeMarker {TargetFigure = source},
                    new TopMiddleSizeMarker {TargetFigure = source},
                    new TopRightSizeMarker {TargetFigure = source},
                    new MiddleRightSizeMarker {TargetFigure = source},
                    new BottomRightSizeMarker {TargetFigure = source},
                    new BottomMiddleSizeMarker {TargetFigure = source},
                    new BottomLeftSizeMarker {TargetFigure = source},
                    new MiddleLeftSizeMarker {TargetFigure = source}
                };
            return markers;
        }

        public void DrawSizeMarkers(Graphics graphics)
        {
            foreach (var marker in SizeMarkers)
            {
                marker.UpdateLocation();
                marker.Draw(graphics);
            }
        }
        public void DrawVertexMarkers(Graphics graphics)
        {
            if (source is IVertexSupport)
            {
                ((IVertexSupport)source).DrawVertexMarkers(graphics);
            }
        }

        public override bool PointInFigure(PointF point)
        {
            if (source != null)
            {
                return source.PointInFigure(point);
            }
            else {
                return false;
            }
        }

        public override void AddFigureToGraphicsPath(GraphicsPath gp)
        {
            throw new NotImplementedException();
        }
    }
}
