using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XunitTestSample
{
    public class Service1 : IService1
    {
        public int ServiceMethod(int num) => num + 1;
    }

    public interface IService1
    {
        public int ServiceMethod(int num);
    }
}
