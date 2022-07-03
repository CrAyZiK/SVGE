using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVectorGraphicsEditor
{
    class Context
    {
        private IStrategy _strategy;

        public Context() { }
        public Context(IStrategy strategy) { _strategy = strategy; }
        public void SetStrategy(IStrategy strategy) { _strategy = strategy; }
        public object ExecStrategy(object[] data) { return _strategy.execute(data);  }
    }
}
