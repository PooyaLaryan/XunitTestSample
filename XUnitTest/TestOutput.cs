using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace XUnitTest
{
    public class TestOutput
    {
        private readonly ITestOutputHelper output;

        public TestOutput(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void OutTest() 
        {
            output.WriteLine("In the Test");
        }
    }
}
