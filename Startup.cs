using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace ChatApp
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
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<AppUser>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

//            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
//                    options => { options.LoginPath = "/identity/account/login"; });
            services.AddControllersWithViews();
            services.AddRazorPages();
//            services.ConfigureApplicationCookie(options =>
//            {
//                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
//                options.Cookie.Name = "YourAppCookieName";
//                options.Cookie.HttpOnly = true;
//                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
//                options.LoginPath = "/Identity/Account/Login";
//
//                // ReturnUrlParameter requires 
//                //using Microsoft.AspNetCore.Authentication.Cookies;
//                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
//                options.SlidingExpiration = true;
//            });

//            services.Configure<CookiePolicyOptions>(options =>
//            {
//                options.ConsentCookie.IsEssential = true;
//                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
//                options.CheckConsentNeeded = context => false;
//                options.MinimumSameSitePolicy = SameSiteMode.None;
//            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

//            app.UseCookiePolicy();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}