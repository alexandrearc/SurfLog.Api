﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

                //DEV only configuration
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireDigit = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<SurfLogContext>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o => o.Events = new CookieAuthenticationEvents(){
                    OnRedirectToLogin = (ctx) => {
                        if(ctx.Response.StatusCode == 200){
                            ctx.Response.StatusCode = 401;
                        }
                        return Task.CompletedTask;
                    },
                    OnRedirectToAccessDenied = (ctx) => {
                        if(ctx.Response.StatusCode == 200){
                            ctx.Response.StatusCode = 403;
                        }
                        return Task.CompletedTask;
                    }
                });
            
            services.AddScoped<IDbInitializer, DbInitializer>();

            services.AddTransient<IBeachRepository, BeachRepository>();   
            services.AddTransient<IBeachService, BeachService>();   
            services.AddTransient<ISessionRepository , SessionRepository>(); 
            services.AddTransient<ISessionService , SessionService>(); 
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddMvc(); 
            services.AddAutoMapper();                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IDbInitializer dbInitializer)
        {
            //The order on this method matters!

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            dbInitializer.Initialize();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
