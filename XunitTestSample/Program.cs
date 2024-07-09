using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XunitTestSample;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddScoped<IService1, Service1>();
        services.AddScoped<RunProject>();
    }).Build();

var runProject = host.Services.GetRequiredService<RunProject>();
runProject.Run();

await host.RunAsync();

