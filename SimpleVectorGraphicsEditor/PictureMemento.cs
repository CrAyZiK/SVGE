using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVectorGraphicsEditor
{
    public class PictureMemento
    {
        public List<Figure> Figures { get; private set; }
        public PictureMemento(List<Figure> figs) {
            this.Figures = new List<Figure>();
            foreach(var fig in figs) this.Figures.Add((Figure)fig.Clone());
         }
    }
}
