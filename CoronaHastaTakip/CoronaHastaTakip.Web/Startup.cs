using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaHastaTakip.Business.Concrete;
using CoronaHastaTakip.Business.Interfaces;
using CoronaHastaTakip.DataAccess.Concrete.Context;
using CoronaHastaTakip.DataAccess.Concrete.Repositories;
using CoronaHastaTakip.DataAccess.Interfaces;
using CoronaHastaTakip.Entities.Concrete;
using CoronaHastaTakipTaslak.Business.Concrete;
using CoronaHastaTakipTaslak.Business.Interfaces;
using CoronaHastaTakipTaslak.DataAccess.Concrete.Repositories;
using CoronaHastaTakipTaslak.DataAccess.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoronaHastaTakip.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IHastaService, HastaManager>();
            services.AddScoped<IAciliyetService, AciliyetManager>();
            services.AddScoped<IRaporService, RaporManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IBildirimService, BildirimManager>();
            services.AddScoped<IDosyaService, DosyaManager>();

            services.AddScoped<IHastaDal, HastaDal>();
            services.AddScoped<IAciliyetDal, AciliyetDal>();
            services.AddScoped<IRaporDal, RaporDal>();
            services.AddScoped<IAppUserDal, AppUserDal>();
            services.AddScoped<IBildirimDal, BildirimDal>();

            services.AddDbContext<CoronaHastaTakipContext>();
            
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequiredLength = 1;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<CoronaHastaTakipContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "Cookie";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(30);
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Index";
            });


            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            IdentityInitializer.SeedData(userManager, roleManager).Wait();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller=AnaSayfa}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
