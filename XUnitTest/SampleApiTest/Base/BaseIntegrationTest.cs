using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using XUnitTest.Attributes;

namespace XUnitTest.SampleApiTest.Base
{
    [AutoRollback]
    public class BaseIntegrationTest
    {
        protected readonly WebApplicationFactory<Program> Application;
        protected readonly IConfiguration Configuration;
        private HttpClient _clientRequest;

        protected BaseIntegrationTest()
        {
            Application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.UseTestServer(testServerOptions => testServerOptions.PreserveExecutionContext = true);
                    builder.UseEnvironment("Test");

                    builder.ConfigureServices(services =>
                    {
                        builder.ConfigureAppConfiguration((context, configurationBuilder) =>
                        {
                            configurationBuilder.AddEnvironmentVariables();
                        });
                    });
                });
            Configuration = Application.Server.Services.GetService<IConfiguration>()!;
        }

        protected HttpClient ClientRequest
        {
            get
            {
                _clientRequest = Application.CreateClient();
                return _clientRequest;
            }
        }

        /*protected HttpClient AdminClient
        {
            get
            {
                if (_adminClient?.DefaultRequestHeaders.Authorization != null) return _adminClient;
                _adminClient = Application.CreateClient();
                var token = GetAdminApiTokenAsync().Result;
                _adminClient!.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", token);
                return _adminClient;
            }
        }*/
    }
}
