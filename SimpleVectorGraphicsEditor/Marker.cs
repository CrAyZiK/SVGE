using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleVectorGraphicsEditor
{
    /// <summary>
    /// Признак размерного маркера
    /// </summary>
    public interface ISizeMarker { }

    [Serializable]
    public abstract class Marker
    {
        protected static int DefSize = 4;

        public Figure TargetFigure;

        public abstract Cursor Cursor { get; }

        public abstract int Index { get; }

        public bool IsInsidePoint(Point p)
        {
            if (p.X < Location.X - DefSize || p.X > Location.X + DefSize)
                return false;
            if (p.Y < Location.Y - DefSize || p.Y > Location.Y + DefSize)
                return false;
            return true;
        }

        public abstract void UpdateLocation();

        public virtual PointF Location { get; set; }

        public virtual void Draw(Graphics gr)
        {
            gr.DrawRectangle(Pens.Black, Location.X - DefSize,
                Location.Y - DefSize, DefSize * 2, DefSize * 2);
            gr.FillRectangle(Brushes.Violet, Location.X - DefSize,
                Location.Y - DefSize, DefSize * 2, DefSize * 2);
        }
    }

    [Serializable]
    public class TopLeftSizeMarker : Marker, ISizeMarker
    {
        public override int Index { get { return 1; } }

        public override Cursor Cursor { get { return Cursors.SizeNWSE; } }

        public override void UpdateLocation()
        {
            if (TargetFigure == null) return;
            var bounds = TargetFigure.Bounds;
            Location = new Point((int)Math.Round(bounds.Left) - DefSize / 2,
                                 (int)Math.Round(bounds.Top) - DefSize / 2);
        }
    }

    [Serializable]
    public class TopMiddleSizeMarker : Marker, ISizeMarker
    {
        public override int Index { get { return 2; } }

        public override Cursor Cursor { get { return Cursors.SizeNS; } }

        public override void UpdateLocation()
        {
            if (TargetFigure == null) return;
            var bounds = TargetFigure.Bounds;
            Location = new Point((int)Math.Round(bounds.Left + bounds.Width / 2),
                                 (int)Math.Round(bounds.Top) - DefSize / 4);
        }
    }

    [Serializable]
    public class TopRightSizeMarker : Marker, ISizeMarker
    {
        public override int Index { get { return 3; } }

        public override Cursor Cursor { get { return Cursors.SizeNESW; } }

        public override void UpdateLocation()
        {
            if (TargetFigure == null) return;
            var bounds = TargetFigure.Bounds;
            Location = new Point((int)Math.Round(bounds.Right) + DefSize / 4,
                                 (int)Math.Round(bounds.Top) - DefSize / 4);
        }
    }

    [Serializable]
    public class MiddleRightSizeMarker : Marker, ISizeMarker
    {
        public override int Index { get { return 4; } }

        public override Cursor Cursor { get { return Cursors.SizeWE; } }

        public override void UpdateLocation()
        {
            if (TargetFigure == null) return;
            var bounds = TargetFigure.Bounds;
            Location = new Point((int)Math.Round(bounds.Right) + DefSize / 4,
                                 (int)Math.Round(bounds.Top + bounds.Height / 2));
        }
    }

    [Serializable]
    public class BottomRightSizeMarker : Marker, ISizeMarker
    {
        public override int Index { get { return 5; } }

        public override Cursor Cursor { get { return Cursors.SizeNWSE; } }

        public override void UpdateLocation()
        {
            if (TargetFigure == null) return;
            var bounds = TargetFigure.Bounds;
            Location = new Point((int)Math.Round(bounds.Right) + DefSize / 4,
                                 (int)Math.Round(bounds.Bottom) + DefSize / 4);
        }
    }

    [Serializable]
    public class BottomMiddleSizeMarker : Marker, ISizeMarker
    {
        public override int Index { get { return 6; } }

        public override Cursor Cursor { get { return Cursors.SizeNS; } }

        public override void UpdateLocation()
        {
            if (TargetFigure == null) return;
            var bounds = TargetFigure.Bounds;
            Location = new Point((int)Math.Round(bounds.Left + bounds.Width/2),
                                 (int)Math.Round(bounds.Bottom) + DefSize / 4);
        }
    }

    [Serializable]
    public class BottomLeftSizeMarker : Marker, ISizeMarker
    {
        public override int Index { get { return 7; } }

        public override Cursor Cursor { get { return Cursors.SizeNESW; } }

        public override void UpdateLocation()
        {
            if (TargetFigure == null) return;
            var bounds = TargetFigure.Bounds;
            Location = new Point((int)Math.Round(bounds.Left) - DefSize / 4,
                                 (int)Math.Round(bounds.Bottom) + DefSize / 4);
        }
    }

    [Serializable]
    public class MiddleLeftSizeMarker : Marker, ISizeMarker
    {
        public override int Index { get { return 8; } }

        public override Cursor Cursor { get { return Cursors.SizeWE; } }

        public override void UpdateLocation()
        {
            if (TargetFigure == null) return;
            var bounds = TargetFigure.Bounds;
            Location = new Point((int)Math.Round(bounds.Left) - DefSize / 4,
                                 (int)Math.Round(bounds.Top + bounds.Height/2));
        }
    }

    [Serializable]
    public class VertexLocationMarker : Marker
    {
        private readonly int _index;

        public VertexLocationMarker(int index)
        {
            _index = index;
        }

        public override int Index { get { return _index; } }

        public override Cursor Cursor { get { return Cursors.SizeAll; } }

        public override void UpdateLocation()
        {
            if (TargetFigure == null) return;
            var points = TargetFigure.GetPoints();
            if (_index < 0 || _index >= points.Length) return;
            Location = new Point((int)points[_index].X, (int)points[_index].Y);
        }

        public override void Draw(Graphics gr)
        {
            gr.DrawEllipse(Pens.Black, Location.X - DefSize,
                Location.Y - DefSize, DefSize * 2, DefSize * 2);
            gr.FillEllipse(Brushes.DarkOrange, Location.X - DefSize,
                Location.Y - DefSize, DefSize * 2, DefSize * 2);
        }
    }

}
