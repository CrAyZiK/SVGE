using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVectorGraphicsEditor
{
    class PictureHistory
    {
        public Stack<PictureMemento> History { get; private set; }
        public PictureHistory() {
            this.History = new Stack<PictureMemento>();
        }
    }
}
