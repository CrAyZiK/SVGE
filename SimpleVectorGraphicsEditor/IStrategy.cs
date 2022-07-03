using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVectorGraphicsEditor
{
    internal interface IStrategy
    {
        object execute(object[] data);
    }
}
