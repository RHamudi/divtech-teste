using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using divtech_teste.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace divtech_teste.Data.Mappings
{
    public class FornecedoresMap : IEntityTypeConfiguration<Fornecedores>
    {
        public void Configure(EntityTypeBuilder<Fornecedores> builder)
        {
            builder.ToTable("Fornecedores");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);
            
            builder.Property(x => x.CNPJ)
                .IsRequired()
                .HasColumnName("CNPJ")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(14);
            
            builder.Property(x => x.Especialidade)
                .IsRequired()
                .HasColumnName("Especialidade")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);
        }
    }
}