using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest.SampleApiTest.Builder.Base
{
    public class BuilderBase
    {
        private List<string> SpecificProperties = new();
        protected void AssignSpecificProperty(string propertyName) => SpecificProperties.Add(propertyName);
        protected bool IsPropertyAssigned(string propertyName) => SpecificProperties.Contains(propertyName);
    }
}
