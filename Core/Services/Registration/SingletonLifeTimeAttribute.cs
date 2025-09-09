using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Registration
{
    [AttributeUsage(AttributeTargets.Class)]
    class SingletonLifeTimeAttribute : Attribute
    {
    }
}
