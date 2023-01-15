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
            optionsBuilder.UseSqlServer("server=localhost\\sqlexpress;database=divtech;trusted_connection=true;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FornecedoresMap());
        }
    }
}