using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivingCarPark.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using LivingCarPark.Data.Entities;

namespace LivingCarPark
{
    public class Startup
    {
        private IConfiguration _config;

      
        public Startup(IConfiguration config)
        {

            _config = config;

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
          
            //Add DBContext and fetch ConnectionString from config
            services.AddDbContext<LivingCarParkContext>(cfg =>
            {
                cfg.UseSqlServer(_config.GetConnectionString("DBConnectionString"));

            });

            //Register services needed for dependency injection, using ApplicationUser class
            services.AddIdentity<CarParkUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<LivingCarParkContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseStaticFiles();
            //User authentication and use the configuration specified in ConfigureServices
            app.UseAuthentication();
            app.UseMvc(cfg =>
            {
                cfg.MapRoute("Default",
                    "/{controller}/{action}/{id?}",
                    new { controller = "Account", Action = "Login" });
            });
            app.UseMvcWithDefaultRoute();
        }
    }
}
