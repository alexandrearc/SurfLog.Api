using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SurfLog.Api.Models;
using SurfLog.Api.Repositories;
using SurfLog.Api.Services;

namespace SurfLog.Api
{
    public class Startup
    {
        private readonly string _contentRootPath;

        public Startup(IHostingEnvironment environment)
        {
            _contentRootPath = environment.ContentRootPath;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_contentRootPath)
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SurfLogContext>(options => options.UseSqlite(Configuration.GetConnectionString("EntityConnection")).UseMemoryCache(null));
            
            services.AddIdentity<User, Role>(config => {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<SurfLogContext>();

            services.AddTransient<IBeachRepository, BeachRepository>();   
            services.AddTransient<IBeachService, BeachService>();   
            services.AddTransient<ISessionRepository , SessionRepository>(); 
            services.AddTransient<ISessionService , SessionService>(); 

            services.AddMvc();                 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //The order on this method matters!

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
