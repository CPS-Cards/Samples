using Microsoft.EntityFrameworkCore;
using System;

namespace MyPCL
{
    public class MyDataContext : DbContext
    {
        public DbSet<MyNewTable> MyNewTable { get; set; }

        public MyDataContext() { }

        public MyDataContext(DbContextOptions<MyDataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.EnableSensitiveDataLogging(true);

                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
    }
}
