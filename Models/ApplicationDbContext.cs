using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestIT.Models
{
    public class ApplicationDbContext : DbContext

    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }//added
        public DbSet<Answer> Answers { get; set; }//added

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            
        }
    }
}
