using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest.ClassFixtures
{
    public class MyClassFixtuer : IDisposable
    {
        public MyClassFixtuer()
        {
            Db = "MyClassFixtuer";
        }
        public void Dispose()
        {
            //do anything
        }

        public string Db { get; private set; }
    }
}
