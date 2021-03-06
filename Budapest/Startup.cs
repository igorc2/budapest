﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Budapest.API.Entities;
using Budapest.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace Budapest
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //public static IConfigurationRoot Configuration;

        //public Startup(IHostingEnvironment env)
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(env.ContentRootPath)
        //        .AddJsonFile("appSettings.json", optional:false, reloadOnChange: true);

        //    Configuration = builder.Build();
        //}


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions( o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter())
                );

#if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
#else
            services.AddTransient<IMailService, CloudMailService>();
#endif
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=CityInfoDB;Trusted_Connection=True";
            services.AddDbContext<CityInfoContext>( o => o.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            //loggerFactory.AddProvider(new NLog.Extensions.Logging.NLogLoggerProvider());
            loggerFactory.AddNLog();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseStatusCodePages();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
