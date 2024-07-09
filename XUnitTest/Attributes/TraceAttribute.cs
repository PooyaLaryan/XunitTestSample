using System.Diagnostics;
using System.Reflection;
using Xunit.Sdk;

namespace XUnitTest.Attributes;

class TraceAttribute : BeforeAfterTestAttribute
{
    public override void Before(MethodInfo methodUnderTest)
    {
        Trace.WriteLine(
            string.Format(
                "Before : {0}.{1}",
                methodUnderTest.DeclaringType.FullName,
                methodUnderTest.Name));
    }

    public override void After(MethodInfo methodUnderTest)
    {
        Trace.WriteLine(
            string.Format(
                "After : {0}.{1}",
                methodUnderTest.DeclaringType.FullName,
                methodUnderTest.Name));
    }
}
