using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ItemStore.Logic.Interfaces;
using ItemStore.Logic.Models.User;
using ItemStore.Data;
using ItemStore.Interface.Interfaces;
using ItemStore.Logic.Models.Item;
using ItemStore.Data.DAL;
using ItemStore.Logic.Salt;
using Microsoft.Extensions.Options;
using ItemStore.Data.SqlDbAcces;

namespace ItemStore.Presentation
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

            //Enable cookie authentication 
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie();

            //register dependencies
            services.AddScoped<IUserContainer, UserContainer>();
            services.AddScoped<IUserDAL, UserDAL>();
            services.AddScoped<IItemContainer, ItemContainer>();
            services.AddScoped<IItemDAL, ItemDAL>();

            // Set the Salt for password hashing
            Action<PasswordSalt> passwordSalt = (opt =>
            {
                opt.Salt = "$%19#";
            });
            services.Configure(passwordSalt);
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<PasswordSalt>>().Value);

            Action<ConnectionString> connectionString = (opt =>
            {
                opt.connectionString = "Data Source=LAPTOP-M87NBEN5;Initial Catalog=AppDB;Integrated Security=True";
            });

            services.Configure(connectionString);
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<ConnectionString>>().Value);

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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Add authentication 
            app.UseAuthentication(); 

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
