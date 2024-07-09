using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest.ClassFixtures
{
    public class MyClassTest2 : IClassFixture<MyClassFixtuer>
    {
        private readonly MyClassFixtuer fixtuer;

        public MyClassTest2(MyClassFixtuer fixtuer)
        {
            this.fixtuer = fixtuer;
        }

        [Fact]
        public void TestClass()
        {
            var t = fixtuer.Db;
            Trace.WriteLine("MyClassTest2 TestClass");
        }
    }
}
