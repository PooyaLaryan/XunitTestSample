using Moq;
using SampleApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest.SampleApiTest.IntegrationTest
{
    internal class PersonControllerTest
    {
        private readonly Mock<IPersonService> _personService;
        public PersonControllerTest()
        {
            _personService = new Mock<IPersonService>(MockBehavior.Strict);

        }
    }
}
