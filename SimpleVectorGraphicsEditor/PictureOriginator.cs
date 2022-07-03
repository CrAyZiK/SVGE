using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVectorGraphicsEditor
{
    public class PictureOriginator
    {

        private List<Figure> figures = new List<Figure>();

        public List<Figure> Figures { get => figures; }

        // сохранение состояния
        public PictureMemento SaveState()
        {
            return new PictureMemento(figures);
        }

        // восстановление состояния
        public void RestoreState(PictureMemento memento)
        {
            this.figures=memento.Figures;
        }
    }
}
