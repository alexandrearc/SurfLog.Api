using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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

            services.Configure<JWTSettings>(Configuration.GetSection("JWTSettings"));
            
            services.AddIdentity<User, Role>(config => {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 8;

                //DEV only configuration
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireDigit = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<SurfLogContext>();

             // secretKey contains a secret passphrase only your server knows
            var secretKey = Configuration.GetSection("JWTSettings:SecretKey").Value;
            var issuer = Configuration.GetSection("JWTSettings:Issuer").Value;
            var audience = Configuration.GetSection("JWTSettings:Audience").Value;
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                // Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,
                ValidIssuer = issuer,

                // Validate the JWT Audience (aud) claim
                ValidateAudience = true,
                ValidAudience = audience
            };

            services
                .AddAuthentication( o => {
                     o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    }
                )
                .AddCookie(o => o.Events = new CookieAuthenticationEvents(){
                    OnRedirectToLogin = (ctx) => {
                        if(ctx.Response.StatusCode == 200){
                            ctx.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                        }
                        return Task.CompletedTask;
                    },
                    OnRedirectToAccessDenied = (ctx) => {
                        if(ctx.Response.StatusCode == 200){
                            ctx.Response.StatusCode = (int) HttpStatusCode.Forbidden;
                        }
                        return Task.CompletedTask;
                    }
                })
                .AddJwtBearer( o => {
                    o.TokenValidationParameters = tokenValidationParameters;
                });
            
            //TODO: Check why this is needed
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();
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

                //If you drop the database comment this line before update migrations.
                dbInitializer.Initialize();
            }

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
