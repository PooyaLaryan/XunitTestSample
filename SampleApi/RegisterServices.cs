using Microsoft.EntityFrameworkCore;
using SampleApi.Data;
using SampleApi.Infrastructure;
using SampleApi.Repository;
using SampleApi.Service;

namespace SampleApi
{
    public static class RegisterServices
    {
        public static void Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(dbContextOptionBuilder => {
                 dbContextOptionBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
             });

            services.AddScoped<IPersonRepository, PersonRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IPersonService, PersonService>();
        }
    }
}
