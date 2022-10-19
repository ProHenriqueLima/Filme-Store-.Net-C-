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
    public class AluguelMapping : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataDoAluguel)
                .IsRequired()
                    .HasColumnType("datetime");
            
            builder.Property(x => x.DataDaDevolucao)
                    .HasColumnType("datetime");
            
            builder.Property(x => x.DataDePrevisao)
                    .HasColumnType("datetime");

            builder.Property(x => x.Situacao)
                    .HasColumnType("varchar");
            
            builder.Property(x => x.Ativo)
                    .HasColumnType("bit");

            builder.HasOne(x => x.Cliente);

            builder.HasOne(x => x.Filme);



        }
    }
}