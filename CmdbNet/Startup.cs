using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CmdbNet.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CmdbNet
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
                        
            services.AddDbContext<CmdbNetContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CmdbNetContext")));

            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    "IsCustodian",
                    policyBuilder => policyBuilder.RequireAssertion(
                        context => context.User.HasClaim(claim =>
                                       context.User.Identity.Name == "NOS\\Deana.Mastin"
                                       || context.User.Identity.Name == "NOS\\John.Celmer"
                                       || context.User.Identity.Name == "NOS\\Saron.Desta"
                                       || context.User.Identity.Name == "NOS\\Joseph.Hoang")
                                    )
                    );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
