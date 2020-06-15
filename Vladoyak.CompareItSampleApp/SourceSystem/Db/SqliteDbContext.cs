using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SourceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SourceSystem.Db
{
    public class SqliteDbContext: DbContext
    {
        public SqliteDbContext(DbContextOptions<SqliteDbContext> options)
            :base(options)
        {           
        }

        public DbSet<Insurance> Insurances { get; set; }
    }
}
