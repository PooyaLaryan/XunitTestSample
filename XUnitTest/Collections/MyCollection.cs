using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest.Collections;

// Turn off parallelism for specific Test Collection
// [CollectionDefinition(DisableParallelization = true)]
[CollectionDefinition("MyCollection collection")]
public class MyCollectionBase : ICollectionFixture<MyCollectionFixture>
{
}
