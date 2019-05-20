using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PersonnelApi.Models
{
    public class KDTestContext : DbContext
    {
        public DbSet<Person> Personnel { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=KTestDB;Integrated Security=True"
            );
        }
    }
}