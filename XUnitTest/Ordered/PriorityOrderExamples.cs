namespace XUnitTest.Ordered;

[TestCaseOrderer("XUnitTest.Ordered.PriorityOrdererStrategy", "XUnitTest")]
public class PriorityOrderExamples
{
    [Fact, TestPriority(1)]
    public void Test1()
    {
        Console.WriteLine("1");
    }

    [Fact, TestPriority(3)]
    public void Test3()
    {
        Console.WriteLine("3");
    }

    [Fact, TestPriority(2)]
    public void Test2()
    {
        Console.WriteLine("2");
    }
}