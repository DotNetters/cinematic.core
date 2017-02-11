using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Cinematic.Web.Data;
using Cinematic.Web.Models;
using Cinematic.Web.Services;
using Cinematic.Domain.Contracts;
using Cinematic.DAL;
using Cinematic.Domain;

namespace Cinematic.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            //if (env.IsDevelopment())
            //{
            //    // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
            //    builder.AddUserSecrets();
            //}

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                //options.UseSqlServer(Configuration["DataConfiguration:DBConnection"]));
                options.UseSqlite(Configuration["DataConfiguration:DBConnection"]));

            services.AddDbContext<CinematicEFDataContext>(options =>
                //options.UseSqlServer(Configuration["DataConfiguration:DBConnection"]));
                options.UseSqlite(Configuration["DataConfiguration:DBConnection"]));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            services.AddOptions()
                .Configure<DataConfiguration>(Configuration.GetSection(nameof(DataConfiguration)));

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            // App services	
            // Register the service and implementation for the database context
            services.AddScoped<IDataContext>(provider => provider.GetService<CinematicEFDataContext>());
            services.AddTransient<ISessionManager, SessionManager>();
            services.AddTransient<ITicketManager, TicketManager>();
            services.AddTransient<IPriceManager, PriceManager>();
            services.AddTransient<ISeatManager, SeatManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            loggerFactory.CreateLogger<Startup>().LogInformation("DBConnection: {0}", Configuration["DataConfiguration:DBConnection"]);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
