using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest.Collections
{
    public class MyCollectionFixture : IDisposable
    {
        public MyCollectionFixture()
        {
            Db = "Create Db";
        }
        public void Dispose()
        {
            //Do Anythings
        }
        public string Db { get; private set; }
    }
}
