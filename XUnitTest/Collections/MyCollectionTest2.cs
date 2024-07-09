using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest.Collections;

[Collection("MyCollection collection")]
public class MyCollectionTest2
{
    private readonly MyCollectionFixture fixture;

    public MyCollectionTest2(MyCollectionFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public void TestClass()
    {
        var t = fixture.Db;

    }
}
