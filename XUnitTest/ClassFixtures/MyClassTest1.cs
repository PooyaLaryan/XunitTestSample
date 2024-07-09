using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest.ClassFixtures
{
    public class MyClassTest1 : IClassFixture<MyClassFixtuer>
    {
        private readonly MyClassFixtuer fixtuer;

        public MyClassTest1(MyClassFixtuer fixtuer)
        {
            this.fixtuer = fixtuer;
        }

        [Fact]
        public void TestClass()
        {
            var t = fixtuer.Db;

        }
    }
}
