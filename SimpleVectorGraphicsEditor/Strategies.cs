using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleVectorGraphicsEditor
{
    class StrategyFKDU : IStrategy
    {
        public object execute(object[] data)
        {
            Picture picture = data[0] as Picture;
            float step = (float)data[1];

            picture.FileChanged = true;
            picture._selected[0].Drag(new PointF(0, -step));
            picture._container.Invalidate();
            return true;
        }
    }
    class StrategyFKDD : IStrategy
    {
        public object execute(object[] data)
        {
            Picture picture = data[0] as Picture;
            float step = (float)data[1];

            picture.FileChanged = true;
            picture._selected[0].Drag(new PointF(0, step));
            picture._container.Invalidate();
            return true;
        }
    }
    class StrategyFKDL : IStrategy
    {
        public object execute(object[] data)
        {
            Picture picture = data[0] as Picture;
            float step = (float)data[1];

            picture.FileChanged = true;
            picture._selected[0].Drag(new PointF(-step, 0));
            picture._container.Invalidate();
            return true;
        }
    }
    class StrategyFKDR : IStrategy
    {
        public object execute(object[] data)
        {
            Picture picture = data[0] as Picture;
            float step = (float)data[1];

            picture.FileChanged = true;
            picture._selected[0].Drag(new PointF(step, 0));
            picture._container.Invalidate();
            return true;
        }
    }
    class StrategyFKDDel : IStrategy
    {
        public object execute(object[] data)
        {
            Picture picture = data[0] as Picture;
            float step = (float)data[1];

            if ((picture._selected[0].Count > 0) &&
                    (MessageBox.Show(@"Удалить выделенные объекты?", @"Редактор фигур",
                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                                     MessageBoxDefaultButton.Button3) == DialogResult.Yes))
            {
                picture.FileChanged = true;
                //foreach (var fig in _selected) _figures.Remove(fig);
                //foreach (var fig in _selected) _figures.Remove(fig.Source);
                foreach (var fig in picture._selected[0].Source) picture.__figures.Figures.Remove(fig);
                picture._selected[0].Clear();
                GC.Collect();
                picture._container.Invalidate();
            }
            return true;
        }
    }
}
