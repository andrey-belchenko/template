using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ImportantStuff.Data;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Builder;
using ImportantStuff.Model;
using ImportantStuff.Data.MongoDB;
using Microsoft.Extensions.Options;
using ImportantStuff.Data.MongoDB.Services;

namespace ImportantStuff.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Project>("Projects");
            return builder.GetEdmModel();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            DataConfigurator.ConfigureServices(services, Configuration);
            services.AddOData();
            services.AddMvc();
            services.AddCors();

            services.Configure<BookstoreDatabaseSettings>(Configuration.GetSection(nameof(BookstoreDatabaseSettings)));

            services.AddSingleton<IBookstoreDatabaseSettings>(sp =>sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);

            services.AddSingleton<BookService>();

            services.AddControllers(mvcOptions =>mvcOptions.EnableEndpointRouting = false);


        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(a =>
                {
                    a.AllowAnyOrigin();
                    a.AllowAnyMethod();
                    a.AllowAnyHeader();
                   
                }
            );

            app.UseMvc(b =>
            {
                b.Select().Expand().Filter().OrderBy().MaxTop(null).Count();
                b.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });




            

        
        }
    }
}
