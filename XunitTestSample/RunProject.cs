using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XunitTestSample
{
    public class RunProject
    {
        private readonly IService1 service1;

        public RunProject(IService1 service1)
        {
            this.service1 = service1;
        }

        public void Run()
        {
            Console.WriteLine(service1.ServiceMethod(10));
        }
    }
}
