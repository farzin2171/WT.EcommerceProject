using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication;

namespace WT.EcommerceMVC
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
            services.AddAuthentication(config=> {
                config.DefaultScheme = "Cookie";
                config.DefaultChallengeScheme = "oidc";

            })
                .AddCookie("Cookie")
                //Remember because it is OpenId connect it knows how to use Discoveryendpoint and background process
                .AddOpenIdConnect("oidc",config=> {
                    config.ClientId = "WT.EcommerceClient_MVC";
                    config.ClientSecret = "WT.EcommerceClient_MVC_secret";
                    config.SaveTokens = true;
                    config.Authority = "https://localhost:44355/";
                    config.ResponseType = "code";
                    config.SignedOutCallbackPath = "/Home/Index";


                    // configure cookie claim mapping
                    config.ClaimActions.DeleteClaim("amr");
                    config.ClaimActions.DeleteClaim("s_hash");
                    config.ClaimActions.MapUniqueJsonKey("WT.level", "WT.level");

                    //this send anoher request to get user's claims but the id token is smaller
                    config.GetClaimsFromUserInfoEndpoint = true;

                    // configure scope
                    config.Scope.Clear();
                    config.Scope.Add("openid");
                    config.Scope.Add("profile");
                    config.Scope.Add("WT.scope");
                    config.Scope.Add("EcommerceAdminAPI.admin");
                    config.Scope.Add("EcommerceClientAPI.admin");
                    config.Scope.Add("offline_access");  //for request rfresh token




                });
            services.AddHttpClient();
            services.AddControllersWithViews();
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
                //app.UseHsts();
            }
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
            });
        }
    }
}
