using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using divtech_teste.Models;
using Microsoft.EntityFrameworkCore;
using divtech_teste.Data.Mappings;

namespace divtech_teste.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Fornecedores> Fornecedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=divtech;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FornecedoresMap());
        }
    }
}