using Azure;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using SampleApi.Controllers;
using SampleApi.Infrastructure;
using SampleApi.Service;
using Shouldly;
using System.Net.Http.Json;
using XUnitTest.SampleApiTest.Base;
using XUnitTest.SampleApiTest.Builder;

namespace XUnitTest.SampleApiTest.IntegrationTest;
public class PersonControllerTest : BaseIntegrationTest
{
    [Fact]
    public async void Test1()
    {
        var model = new PersonDtoBuilder().WithName("Pouya")
            .WithDescription("Test Save ")
            .Build();

        var response = await ClientRequest.PostAsJsonAsync("/Person", model);
        var result = await response.Content.ReadFromJsonAsync<int>();

        result.ShouldBe(1);    
    }

    [Fact]
    public async void Test2()
    {
        var model = new PersonDtoBuilder2()
            .With(x => x.Name, "Pouya")
            .With(x => x.Description, "Lariyan")
            .Build();

        var personService = CreateService<IPersonService>();
        var id = await personService.InsertAsync(model);

    }

    [Fact]
    public async void Test3()
    {
        var model = new PersonDtoBuilder2()
            .With(x => x.Name, "Pouya")
            .With(x => x.Description, "Lariyan")
            .Build();

        Mock<IPersonService> mock = new Mock<IPersonService>();
        mock.Setup(x=>x.InsertAsync(model)).ReturnsAsync(1);
        var controller = new PersonController(mock.Object);

        var response = await controller.InsertAsync(model);
    }
}
