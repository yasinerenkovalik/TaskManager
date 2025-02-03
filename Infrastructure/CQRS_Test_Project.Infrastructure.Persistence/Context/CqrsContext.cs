using CQRS_Test_Project.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Test_Project.Infrastructure.Persistence.Context
{
    public class CqrsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Cqrs;User Id=sa;Password=Yasin123!;TrustServerCertificate=True;");
        }

       
        public DbSet<User> Users { get; set; }
    }
}
