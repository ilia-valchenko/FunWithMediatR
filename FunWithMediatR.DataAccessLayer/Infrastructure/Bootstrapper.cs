using FunWithMediatR.DataAccessLayer.Repositories;
using FunWithMediatR.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FunWithMediatR.DataAccessLayer.Infrastructure
{
    public static class Bootstrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
        }
    }
}