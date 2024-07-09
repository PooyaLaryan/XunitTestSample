using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest.ClassFixtures
{
    public class MyClassFixtuer : IDisposable
    {
        public MyClassFixtuer()
        {
            Trace.WriteLine("Create MyClassFixtuer");
            Db = "MyClassFixtuer";
        }
        public void Dispose()
        {
            Trace.WriteLine("Dispose MyClassFixtuer");
        }

        public string Db { get; private set; }
    }
}
