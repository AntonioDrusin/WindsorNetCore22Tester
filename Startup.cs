using System;
using Castle.Facilities.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Castle.Windsor;
using WebApplication2._2.Controllers;
using WebApplication2._2.Services;

namespace WebApplication2._2
{
    public class Startup
    {
        private static readonly WindsorContainer Container = new WindsorContainer();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            Container.AddFacility<AspNetCoreFacility>(f => f.CrossWiresInto(services));

            Container.Install(new Installer());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

             return services.AddWindsor(Container, 
                 opts => opts.UseEntryAssembly(typeof(ValuesController).Assembly), // <- Recommended
                 () => services.BuildServiceProvider(validateScopes:false)); // <- Optional
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
