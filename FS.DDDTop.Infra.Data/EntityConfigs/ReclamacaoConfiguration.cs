using FS.DDDTop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FS.DDDTop.Infra.Data.EntityConfigs
{
    public class ReclamacaoConfiguration : IEntityTypeConfiguration<Reclamacao>
    {
        public void Configure(EntityTypeBuilder<Reclamacao> builder)
        {
            builder.HasKey(x => x.ReclamacaoId);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Resolvida).IsRequired();

            //não precisa configurar os relacionamentos por aqui (FluentAPI) porque já foram definidos nas entidades
            //builder.HasOne<Cliente>().WithMany(c => c.Reclamacoes);

            //a convenção do efcore não tem pluralize
            //modelBuilder.Entity<Reclamacao>().ToTable("Reclamacao");
        }
    }
}
