using FS.DDDTop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FS.DDDTop.Infra.Data.EntityConfigs
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.ProdutoId);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Valor).IsRequired();

            //não precisa configurar os relacionamentos por aqui (FluentAPI) porque já foram definidos nas entidades
            //builder.HasOne<Cliente>().WithMany(c => c.Produtos);

            //a convenção do efcore não tem pluralize
            //modelBuilder.Entity<Cliente>().ToTable("Produto");
        }
    }
}
