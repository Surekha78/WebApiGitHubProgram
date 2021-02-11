using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WebApiGitHubProgram.Data;
using WebApiGitHubProgram.Service;

namespace WebApiGitHubProgram
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
            services.AddControllers();

            services.AddDbContext<WebApiGitHubProgramContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("WebApiGitHubProgramContext")));

            services.AddSingleton<IMyCommunicator, MyCommunicator>();
            // is one time instance per project and it re uses evry time. memory uses may raise for large projects.
            // services.AddTransient<IMyCommunicator, MyCommunicator>();
            // New instance for every controller or service. preferred way for short services such as email or sms. For lightweight 
            // services.AddScoped<IMyCommunicator, MyCommunicator>(); 
            // it creates new instance every time there is request for it.*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                // var context = serviceScope.ServiceProvider.GetRequiredService<WebApiGitHubProgramContext>();
                 // context.Database.Migrate();
               // context.Database.EnsureDeleted(); 
                // context.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
