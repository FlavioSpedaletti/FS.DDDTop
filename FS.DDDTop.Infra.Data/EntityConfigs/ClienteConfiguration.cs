using FS.DDDTop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FS.DDDTop.Infra.Data.EntityConfigs
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.ClienteId);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Sobrenome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);

            //não precisa configurar os relacionamentos por aqui (FluentAPI) porque já foram definidos nas entidades
            //builder.HasMany<Produto>().WithOne(p => p.Cliente).HasForeignKey(p => p.ClienteId);

            //a convenção do efcore não tem pluralize
            //modelBuilder.Entity<Cliente>().ToTable("Cliente");
        }
    }
}
