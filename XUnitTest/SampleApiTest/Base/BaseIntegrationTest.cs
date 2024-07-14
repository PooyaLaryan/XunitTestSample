using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleApi.Controllers;
using XUnitTest.Attributes;

namespace XUnitTest.SampleApiTest.Base;

[AutoRollback]
public class BaseIntegrationTest
{
    protected IServiceCollection services;
    protected readonly IConfiguration Configuration;
    protected WebHostBuilder _hostBuilder;
    
    private readonly WebApplicationFactory<Program> Application;
    private HttpClient _clientRequest;
    private readonly IServiceProvider serviceProvider;
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

                    //services.AddScoped<PersonController>();
                    this.services = services;
                });
            });
        Configuration = Application.Services.GetService<IConfiguration>()!;
        serviceProvider = Application.Services!;
    }

    protected HttpClient ClientRequest
    {
        get
        {
            _clientRequest = Application.CreateClient();
            return _clientRequest;
        }
    }

    protected T CreateService<T>() where T : class
    {
        return serviceProvider.GetRequiredService<T>();
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
