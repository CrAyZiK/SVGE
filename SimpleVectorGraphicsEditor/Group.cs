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
    public class Group : Figure
    {

        ObservableCollection<Figure> figures = new ObservableCollection<Figure>();

        void ComputeBounds() {
            float x = figures[0].Bounds.Left;
            float y = figures[0].Bounds.Top;
            float x1= figures[0].Bounds.Right;
            float y1= figures[0].Bounds.Bottom;
            foreach (var figure in figures) {
                if(figure.Bounds.Left<x) x = figure.Bounds.Left; 
                if(figure.Bounds.Top<y) y = figure.Bounds.Top;
                if(figure.Bounds.Right>x1) x1 = figure.Bounds.Right;
                if(figure.Bounds.Bottom>y1) y1 = figure.Bounds.Bottom;
            }
            if (figures.Count==0) { x = -20; y = -20; x1 =-20; y1 = -20; }
            Location = new PointF(x, y);
            Size = new SizeF(new SizeF(x1-x, y1-y));
            BoundsRect = new RectangleF(new PointF(x, y), new SizeF(x1-x, y1-y));
        }
        RectangleF StretchFigureRect(RectangleF rect, RectangleF oldGRect, RectangleF newGRect) {
            return new RectangleF(
                new PointF(
                    newGRect.X+(-oldGRect.X+rect.X)*(newGRect.Width/oldGRect.Width),
                    newGRect.Y+(-oldGRect.Y+rect.Y)*(newGRect.Height/oldGRect.Height)
                    ), 
                new SizeF(
                    rect.Width  * (1 + ((newGRect.Width-oldGRect.Width)/oldGRect.Width)), 
                    rect.Height * (1 + ((newGRect.Height-oldGRect.Height)/oldGRect.Height))
                    )
                );
        }
        public override void UpdateLocation(PointF offset, RectangleF oldrect, RectangleF newrect) {
            foreach (var figure in figures) figure.UpdateLocation(offset, oldrect, newrect);
            BoundsRect = newrect;
        }
        public override void UpdateSize(PointF offset, RectangleF oldrect, RectangleF newrect, Marker marker) {
            //TODO(CrAyZiK): Check group resizing
            foreach (var figure in figures) { figure.UpdateSize(offset, figure.Bounds, StretchFigureRect(figure.Bounds, oldrect, newrect), marker); }
            BoundsRect = newrect;
        }
        public int Count { get => figures.Count; }
        public ObservableCollection<Figure> Figures { get => figures; }

        public void Add(Figure f) {
            figures.Add(f);
            ComputeBounds();
        }
        public void Remove(Figure f) {
            figures.Remove(f);
            
            ComputeBounds();
        }
        public bool Contains(Figure f) {
            return figures.Contains(f);
        }
        public void Clear() {
            figures.Clear();
            BoundsRect = RectangleF.Empty;
        }
        public override void AddFigureToGraphicsPath(GraphicsPath gp)
        {
            foreach (var figure in figures) { figure.AddFigureToGraphicsPath(gp); }
        }

        public override void Draw(Graphics graphics)
        {
            foreach (var figure in figures) figure.Draw(graphics);
        }

        public override bool PointInFigure(PointF point)
        {
            using (var gp = new GraphicsPath())
            {

                gp.AddRectangle(new RectangleF(new PointF(BoundsRect.X-8, BoundsRect.Y-8), new SizeF(BoundsRect.Width+16, BoundsRect.Height+16)));
                return (gp.IsVisible(point));
            }
        }
        public override void DrawFocusFigure(Graphics graphics, PointF offset, RectangleF oldrect, RectangleF newrect, Marker marker)
        {
            foreach (var figure in figures) { figure.DrawFocusFigure(graphics, offset, oldrect, newrect, marker); }
        }
    }
}
