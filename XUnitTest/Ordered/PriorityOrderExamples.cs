using System.Diagnostics;
using XUnitTest.Attributes;

namespace XUnitTest.Ordered;

[TestCaseOrderer("XUnitTest.Ordered.PriorityOrdererStrategy", "XUnitTest")]
public class PriorityOrderExamples
{
    [Fact, TestPriority(1)]
    public void Test1()
    {
        Console.WriteLine("1");
        Trace.WriteLine("in the Test 1 ");
    }

    [Fact, TestPriority(3), Trace]
    public void Test3()
    {
        Console.Out.WriteLine("3");

        // for write command in output 
        Trace.WriteLine("in the Test 3 ");
    }

    [Fact, TestPriority(2)]
    public void Test2()
    {
        Console.WriteLine("2");
        Trace.WriteLine("in the Test 2 ");
    }
}