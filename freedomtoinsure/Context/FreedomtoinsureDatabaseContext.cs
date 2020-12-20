using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace freedomtoinsure.Context
{
    public class FreedomtoinsureDatabaseContext:DbContext
    {
        public FreedomtoinsureDatabaseContext
       (
           DbContextOptions<FreedomtoinsureDatabaseContext> options
       ) : base(options) { }
    
        public DbSet<UserDetails> userdetails { get; set; }

    }
}
