using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using SampleApi.Data;
using SampleApi.Service;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnitTest.Attributes;
using XUnitTest.SampleApiTest.Base;
using XUnitTest.SampleApiTest.Builder;

namespace XUnitTest.SampleApiTest.IntegrationTest
{

    public class PersonServiceTest : IClassFixture<CustomWebApplicatrionFactory<Program>>
    {
        [AutoRollback]
        [Fact]
        public async void Insert_Person_In_DB()
        {
            Mock<AppDbContext> context = new Mock<AppDbContext>();
            context.

            /*//Arrange
            var dto = new PersonDtoBuilder().Build();
            //Act
            var id = await personService.InsertAsync(dto);

            //Assert
            id.ShouldBe(1);*/
        }
    }
}
