using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteWiPro.Business.Models;

namespace TesteWiPro.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                    .HasColumnType("varchar");
            
            builder.Property(x => x.Email)
                .IsRequired()
                    .HasColumnType("varchar");
            
            builder.Property(x => x.Endereco)
                .IsRequired()
                    .HasColumnType("varchar");

            builder.Property(x => x.Ativo)
                    .HasDefaultValue(true)
                    .IsRequired()
                    .HasColumnType("bit");

        }
    }
}