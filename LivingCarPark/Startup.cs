using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivingCarPark.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using CarParkApi.Data;
using CarParkApi.Data.Entities;
using Microsoft.AspNetCore.Mvc;

using WebApiModels;


namespace LivingCarPark
{
    public class Startup
    {
        private IConfiguration _config;

      
        public Startup(IConfiguration config)
        {

            _config = config;

        }
        public IConfiguration Configuration { get; }
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
                //.AddSignInManager(CarParkSignInManager)
                .AddDefaultTokenProviders();

            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            // configure strongly typed settings objects
            var appSettingsSection = _config.GetSection("AppSettings");
            services.Configure<appsettings>(appSettingsSection);


            services.Configure<MySettingsModel>(_config.GetSection("MySettings"));

            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
                        
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(cfg =>
            {
                cfg.MapRoute("Default",
                    "/{controller}/{action}/{id?}",
                    new { controller = "App", Action = "index" });
            });
           
            
        }

        //// This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddMvc();
        //    services.Configure<MySettingsModel>(Configuration.GetSection("MySettings"));
        //}

        //// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseBrowserLink();
        //        app.UseDeveloperExceptionPage();
        //    }
        //    else
        //    {
        //        app.UseExceptionHandler("/Home/Error");
        //    }

        //    app.UseStaticFiles();

        //    app.UseMvc(routes =>
        //    {
        //        routes.MapRoute(
        //            name: "default",
        //            template: "{controller=Home}/{action=Index}/{id?}");
        //    });
        //}
    }
}
