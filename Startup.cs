﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PersonnelApi.Models;

namespace PersonnelApi
{
    public class Startup
    {
        protected readonly string ALLOWED_CORS_ORIGIN = "https://localhost:8080";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Register the db context so it can be used in the controllers.
            services.AddDbContext<KDTestContext>();

            //enable CORS
            services.AddCors(c => {
                c.AddPolicy("AllowOrigin", options => options.WithOrigins(ALLOWED_CORS_ORIGIN));
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            
            //Enable CORS
            app.UseCors(options => options.WithOrigins(ALLOWED_CORS_ORIGIN));
        }
    }
}
