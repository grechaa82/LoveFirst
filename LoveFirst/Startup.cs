using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoveFirst.Service;
using Microsoft.EntityFrameworkCore;
using LoveFirst.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace LoveFirst
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("Cookie")
                .AddCookie("Cookie", config => {
                    config.LoginPath = "/Auth/Login";
                });
            services.AddAuthorization();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(14);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            Configuration.Bind("Project", new Config());
            
            services.AddControllersWithViews()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Config.ConnectionStrings));
            services.AddTransient<IRepository, Repository>();
            services.AddMvc(/*config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            }*/);
            services.AddMemoryCache();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseStaticFiles();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapDefaultControllerRoute();
                /*endpoint.MapControllerRoute("default", "{id}/{controller=Home}/{action=Index}");*/
                /*endpoint.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");*/
            });
        }
    }
}
