using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SimpleVectorGraphicsEditor
{
    [Serializable]
    public class Oval : Figure, ISolidFigure
    {
        protected RectangleF Basicrect;

        protected Oval()
        {
            Basicrect = new RectangleF();
        }

        protected Oval(Point origin, Point offset)
        {
            Basicrect = new Rectangle(origin, new Size(offset.X, offset.Y));
        }

        public override void Draw(Graphics graphics)
        {
            // заливаем фон кистью
            using (var brush = new SolidBrush(Color.White))
                graphics.FillEllipse(Fill.UpdateBrush(brush), Basicrect);
            // рисуем контур карандашом
            using (var pen = new Pen(Color.Black))
                graphics.DrawEllipse(Stroke.UpdatePen(pen), Rectangle.Ceiling(Basicrect));
        }

        //move into manipulator
        //public override List<Marker> CreateSizeMarkers()
        //{
        //    var markers = new List<Marker>
        //        {
        //            new TopLeftSizeMarker {TargetFigure = this},
        //            new TopMiddleSizeMarker {TargetFigure = this},
        //            new TopRightSizeMarker {TargetFigure = this},
        //            new MiddleRightSizeMarker {TargetFigure = this},
        //            new BottomRightSizeMarker {TargetFigure = this},
        //            new BottomMiddleSizeMarker {TargetFigure = this},
        //            new BottomLeftSizeMarker {TargetFigure = this},
        //            new MiddleLeftSizeMarker {TargetFigure = this}
        //        };
        //    return markers;
        //}

        //move into manipulator
        //public override void DrawSizeMarkers(Graphics graphics)
        //{
        //    foreach (var marker in SizeMarkers)
        //    {
        //        marker.UpdateLocation();
        //        marker.Draw(graphics);
        //    }
        //}

        public override bool PointInFigure(PointF point)
        {
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(Basicrect);
                return (gp.IsVisible(point));
            }
        }

        public override void AddFigureToGraphicsPath(GraphicsPath gp)
        {
            gp.AddEllipse(Basicrect);
        }

        public override void DrawFocusFigure(Graphics graphics, PointF offset, RectangleF oldrect, RectangleF newrect, Marker marker)
        {
            //var newrect = CalcFocusRect(offset, marker is ISizeMarker ? marker : null);
            DrawCustomFigure(graphics, newrect);
        }

        protected static void DrawCustomFigure(Graphics graphics, RectangleF rect)
        {
            // определяем "карандаш" тонкий чёрный пунктирный
            using (var pen = new Pen(Color.Black, 1f))
            {
                pen.DashStyle = DashStyle.Dash;
                graphics.DrawEllipse(pen, Rectangle.Ceiling(rect)); // рисование контура
            }
        }

        public override RectangleF Bounds
        {
            get
            {
                using (var gp = new GraphicsPath())
                {
                    gp.AddRectangle(Basicrect);
                    BoundsRect = gp.GetBounds();
                    return base.Bounds;
                }
            }
        }

        //public override void UpdateLocation(PointF offset)
        //{
        //    // перемещение фигуры
        //    Basicrect = CalcFocusRect(offset, null);
        //    UpdateMarkers();
        //}

        public override void UpdateLocation(PointF offset, RectangleF oldrect, RectangleF newrect)
        {
            // перемещение фигуры
            Basicrect = newrect;
        }

        //public override void UpdateSize(PointF offset, Marker marker)
        //{
        //    if (!(marker is ISizeMarker)) return;
        //    // перемещение границ
        //    Basicrect = CalcFocusRect(offset, marker);
        //    UpdateMarkers();
        //}

        public override void UpdateSize(PointF offset, RectangleF oldrect, RectangleF newrect, Marker marker)
        {
            if (!(marker is ISizeMarker)) return;
            // перемещение границ
            Basicrect = newrect;
        }

        public override void Offset(PointF p)
        {
            Basicrect.Offset(p);
            //UpdateMarkers();
        }

        public class EllipseCreator : Creator
        {
            public override Figure Create(Point location, Point offset)
            {
                return new Oval(location, offset);
            }

        }
        public class EllipseVisualizer : ToolVisualizer
        {
            public override void Draw(Graphics graphics, Point location, Point location2)
            {
                graphics.FillEllipse(Brushes.White, new Rectangle(location, (Size)location2));
                graphics.DrawEllipse(new Pen(Color.Black) { DashStyle = DashStyle.Solid }, new Rectangle(location, (Size)location2));
            }
        }
    }
}
