﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TweeterClone.Plugins;
using TweeterClone.Plugin;

namespace TweeterClone
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            //  services.AddDbContext<TweeterContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<TweeterContext>(opt => opt.UseInMemoryDatabase());
            services.AddTransient<ITweeterMem, ContextInMem>();

            services.AddMvc();

            services.AddSwaggerGen();

          //  services.AddScoped<ITweeterMem, TweeterMem>();

            // services.Add(new ServiceDescriptor(typeof(TweeterDb), new TweeterDb(Configuration.GetConnectionString("DefaultConnection"))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, TweeterContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc(
                routes =>
                {
                    routes.MapRoute("Default", "{controller=CoreUsers}/{action=getAll}/{id?}");

                });

            app.UseSwagger();
            app.UseSwaggerUi();

          //  Dbinitializer.Initialize(context);
        }
    }
}
