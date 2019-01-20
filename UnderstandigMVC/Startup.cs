using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnderstandigMVC.Entities;

namespace UnderstandigMVC
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
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=MVCUnderstaindDB;Trusted_Connection=True;";
            

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //Denne går ind og siger vi skal bruge IUnderstandingMVCRepo som en service man kan bruge,
            //men bruger implamentationen af UnderstandingMVCRepo versionen
            services.AddScoped<IUnderstandingMVCRepo, UnderstandingMVCRepo>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAutoMapper();

            //til database
            services.AddDbContext<MvcContext>(cfg => {


                cfg.UseSqlServer(connectionString);
            });

            //Til database user login
            services.AddIdentity<IdentityUser, IdentityRole>(cfg =>
            {
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequireUppercase = false;


            }).AddEntityFrameworkStores<MvcContext>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MvcContext mvcContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            mvcContext.Seed();
            
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //Bruges til login
            app.UseAuthentication();

            //styre routing
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                    
            });
        }
    }
}
