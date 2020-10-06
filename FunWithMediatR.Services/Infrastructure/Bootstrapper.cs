using System.Collections.Generic;
using FunWithMediatR.Domain.Entities;
using FunWithMediatR.Services.Queries.V1.Person;
using FunWithMediatR.Services.Services;
using FunWithMediatR.Services.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FunWithMediatR.Services.Infrastructure
{
    public static class Bootstrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            RegisterServices(services);
            RegisterHandlers(services);

            DataAccessLayer.Infrastructure.Bootstrapper.ConfigureServices(services);
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
        }

        public static void RegisterHandlers(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<GetAllPersonsQuery, IEnumerable<Person>>, GetAllPersonsHandler>();
            services.AddScoped<IRequestHandler<GetPersonsByFirstNameQuery, IEnumerable<Person>>, GetPersonsByFirstNameHandler>();
            services.AddScoped<IRequestHandler<GetPersonByIdQuery, Person>, GetPersonByIdHandler>();
        }
    }
}