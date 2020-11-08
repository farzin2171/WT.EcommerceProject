using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WT.IdentityServer.Data;
using WT.IdentityServer.Helper;

namespace WT.IdentityServer
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            //Identity Part
            services.AddDbContext<AppDbContext>(config =>
            {
                //config.UseInMemoryDatabase("Memory");
                config.UseSqlServer(connectionString);
            });

            services.AddIdentity<IdentityUser, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();


            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "IdentityServer.Cookie";
                config.LoginPath = "/Auth/Login";
            });

            var assembly = typeof(Startup).Assembly.GetName().Name;

            //This will include Authontication and Authorization
            //Identity server setup infrustructer to use OpenId connect 
            //Identity server is something simmilar to identity the way identity provides for us getting users , authonticating users,roles,claims...
            //Identity server provides for use infrastructure for OAuth,OpeniId connect , here our infrastructure is clients,apis,scopes... 

            //IdentityServer4 docs: http://docs.identityserver.io/en/latest/
            //OAauth Specification: https://tools.ietf.org/html/rfc6749
            //OIDC Specifications: https://openid.net/specs/openid-conne...
            services.AddIdentityServer()
                .AddAspNetIdentity<IdentityUser>()  //with this identity server is aware of model for the user . Dependency between Identity package and identity server
                                                    //.AddInMemoryIdentityResources(Configuration.GetIdentityResources())
                                                    //.AddInMemoryApiScopes(Configuration.GetApiScopes())
                                                    //.AddInMemoryApiResources(Configuration.GetApis())
                                                    //.AddInMemoryClients(Configuration.GetClient())
                 .AddConfigurationStore(options =>
                 {
                     options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                         sql => sql.MigrationsAssembly(assembly));
                 })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                     sql => sql.MigrationsAssembly(assembly));
                })
                .AddDeveloperSigningCredential();
                services.AddControllersWithViews();

            //https://localhost:44365/.well-known/openid-configuration
            //Openid connect is an extention on top of Oauth and Identity server is an OpenId implimentation, which is OAuth included but more
            //this endpoint is what other applications read to know how commnicate with identy server
            //dotnet core middlewares like JwtToken know how to discover this endpoint

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
