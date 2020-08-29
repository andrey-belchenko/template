using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImportantStuff.Data
{
    public static class DataConfigurator
    {
        public static void ConfigureServices( IServiceCollection services, IConfiguration configuration, bool actionIdsOld = true)
        {
            var connection = configuration.GetConnectionString("Connection");
            services.AddDbContext<DataContext>
               (options => options.UseSqlServer(connection));
        }


    }
}
