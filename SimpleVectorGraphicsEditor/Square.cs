using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SimpleVectorGraphicsEditor
{
    [Serializable]
    public class Square : Rect
    {
        private Square() : base()
        {
        }

        private Square(Point origin, Point offset)
            : base(origin, new Point(Math.Min(offset.X, offset.Y), Math.Min(offset.X, offset.Y)))
        {
        }

        //move into manipulator
        //public override List<Marker> CreateSizeMarkers()
        //{
        //    var markers = new List<Marker>
        //        {
        //            new TopMiddleSizeMarker {TargetFigure = this},
        //            new MiddleRightSizeMarker {TargetFigure = this},
        //            new BottomMiddleSizeMarker {TargetFigure = this},
        //            new MiddleLeftSizeMarker {TargetFigure = this}
        //        };
        //    return markers;
        //}

        //rewrite
        //public override void UpdateSize(PointF offset, Marker marker)
        //{
        //    var oldrect = CalcFocusRect(PointF.Empty, marker is ISizeMarker ? marker : null);
        //    var rect = CalcFocusRect(offset, marker);
        //    var size = (oldrect.Width * oldrect.Height < rect.Width * rect.Height)
        //                   ? Math.Max(rect.Width, rect.Height)
        //                   : Math.Min(rect.Width, rect.Height);
        //    Basicrect.Location = rect.Location;
        //    Basicrect.Size = new SizeF(size, size);
        //    if (marker is MiddleRightSizeMarker)
        //        Basicrect.Y -= (Basicrect.Height - oldrect.Height) / 2;
        //    else if (marker is BottomMiddleSizeMarker)
        //        Basicrect.X -= (Basicrect.Width - oldrect.Width) / 2;
        //    else if (marker is MiddleLeftSizeMarker)
        //        Basicrect.Y += -(Basicrect.Height - oldrect.Height) / 2;
        //    else if (marker is TopMiddleSizeMarker)
        //        Basicrect.X += -(Basicrect.Width - oldrect.Width) / 2;
        //    UpdateMarkers();
        //}

        public override void UpdateSize(PointF offset, RectangleF oldrect, RectangleF rect, Marker marker)
        {
            var size = (oldrect.Width * oldrect.Height < rect.Width * rect.Height)
                           ? Math.Max(rect.Width, rect.Height)
                           : Math.Min(rect.Width, rect.Height);
            Basicrect.Location = rect.Location;
            Basicrect.Size = new SizeF(size, size);
            if (marker is MiddleRightSizeMarker)
                Basicrect.Y -= (Basicrect.Height - oldrect.Height) / 2;
            else if (marker is BottomMiddleSizeMarker)
                Basicrect.X -= (Basicrect.Width - oldrect.Width) / 2;
            else if (marker is MiddleLeftSizeMarker)
                Basicrect.Y += -(Basicrect.Height - oldrect.Height) / 2;
            else if (marker is TopMiddleSizeMarker)
                Basicrect.X += -(Basicrect.Width - oldrect.Width) / 2;
        }

        public override void DrawFocusFigure(Graphics graphics, PointF offset, RectangleF oldrect, RectangleF rect, Marker marker)
        {
            //var oldrect = CalcFocusRect(PointF.Empty, marker is ISizeMarker ? marker : null);
            //var rect = CalcFocusRect(offset, marker);
            var size = (oldrect.Width * oldrect.Height < rect.Width * rect.Height)
                           ? Math.Max(rect.Width, rect.Height)
                           : Math.Min(rect.Width, rect.Height);
            rect.Size = new SizeF(size, size);
            if (marker is MiddleRightSizeMarker)
                rect.Y -= (rect.Height - oldrect.Height) / 2;
            else if (marker is BottomMiddleSizeMarker)
                rect.X -= (rect.Width - oldrect.Width) / 2;
            else if (marker is MiddleLeftSizeMarker)
                rect.Y += -(rect.Height - oldrect.Height) / 2;
            else if (marker is TopMiddleSizeMarker)
                rect.X += -(rect.Width - oldrect.Width) / 2;
            DrawCustomFigure(graphics, rect);
        }
        public class SquareCreator : Creator
        {
            public override Figure Create(Point location, Point offset)
            {
                return new Square(location, offset);
            }

        }

        public class SquareVisualizer : ToolVisualizer
        {
            public override void Draw(Graphics graphics, Point location, Point location2)
            {
                var len = Math.Min(location2.X, location2.Y);
                var _rect = new Rectangle(location.X, location.Y, len, len);
                graphics.FillRectangle(Brushes.White, _rect);
                graphics.DrawRectangle(new Pen(Color.Black) { DashStyle = DashStyle.Solid }, _rect);
            }
        }
    }
}
