using ImportantStuff.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImportantStuff.Data
{
    public class DataContext: DbContext
    {
        public DataContext()
        {
            this.Database.Migrate();
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }
        public DbSet<Project> Project { get; set; }
    }
}
