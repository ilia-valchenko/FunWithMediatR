using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;

namespace FunWithMediatR
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            Services.Infrastructure.Bootstrapper.RegisterServices(services);

            services.AddMediatR(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // NOTE: The order is important!

            app.UseRouting();
            //app.UseCors();

            // .AddAuthentication() adds the auth services to the service collection
            // whereas .UseAuthentication() adds the .NET Core's authentication middleware to the pipeline.
            // If you have your own custom middleware, you don't need .UseAuthentication().

            // .AddAuthentication() and .UseAuthentication() isn't enough for activating your authentication even if you
            // implemented your custom authentication handler.
            //app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Person}/{action=GetAsync}/{id}");
            });
        }
    }
}