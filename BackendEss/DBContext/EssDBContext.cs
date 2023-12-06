using BackendEss.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BackendEss.DBContext
{
    public class EssDBContext : DbContext
    {
        public EssDBContext(DbContextOptions<EssDBContext> options) : base(options)
        {

        }

        public DbSet<AppUsers> AppUsers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<UserProject> UserProject { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }


    }
}
