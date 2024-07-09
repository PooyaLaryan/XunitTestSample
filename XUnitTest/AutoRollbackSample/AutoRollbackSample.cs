using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnitTest.Attributes;

namespace XUnitTest.AutoRollbackSample
{
    public class AutoRollbackSample
    {
        [AutoRollback]
        public void AutoRollbackTest()
        {

        }
    }


    // Or
    [AutoRollback]
    public class AutoRollbackClassSample
    {
        public void AutoRollbackTest1()
        {

        }

        public void AutoRollbackTest2()
        {

        }
    }
}
