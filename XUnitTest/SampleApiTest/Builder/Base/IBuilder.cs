using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest.SampleApiTest.Builder.Base
{
    internal interface IBuilder<T>
    {
        T Build();
    }
}
