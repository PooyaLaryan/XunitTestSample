using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.ObjectPool;
using SampleApi.Data;
using SampleApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest.SampleApiTest.Base;

public class CustomWebApplicatrionFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
        builder.UseEnvironment("Test");

        builder.ConfigureTestServices(services => {
            //services.RemoveAll(typeof(DbContextOptions<AppDbContext>));
            /*services.AddDbContext<AppDbContext>(async (context, options) =>
            {
                options.UseSqlServer("Server=.;Initial Catalog=SampleTest_Testing;User Id=sa;password=123Abc!@#$%;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true");
                var dbContext = context.GetRequiredService<AppDbContext>();
                await dbContext.Database.EnsureCreatedAsync();   
            });*/
        });
    }
}
