using Moq;
using SampleApi.Service;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using XUnitTest.Attributes;
using XUnitTest.SampleApiTest.Base;
using XUnitTest.SampleApiTest.Builder;

namespace XUnitTest.SampleApiTest.IntegrationTest
{
    
    public class PersonControllerTest : BaseIntegrationTest
    {
        [Fact]
        public async void Test()
        {
            var model = new PersonDtoBuilder().WithName("Pouya")
                .WithDescription("Test Save ")
                .Build();

            var response = await ClientRequest.PostAsJsonAsync("/Person", model);
            var result = await response.Content.ReadFromJsonAsync<int>();

            result.ShouldBe(1);    
        }
    }
}
