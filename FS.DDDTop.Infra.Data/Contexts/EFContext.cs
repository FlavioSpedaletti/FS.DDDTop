using FS.DDDTop.Domain.Entities;
using FS.DDDTop.Infra.Data.EntityConfigs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FS.DDDTop.Infra.Data.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reclamacao> Reclamacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //remove comportamente de cascade delete (TALVEZ)
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new ReclamacaoConfiguration());

            //configura os campos string para varchar(100), mas o problema é que sobrescreve as data annotations da entidade
            //foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
            //{
            //    property.Relational().ColumnType = "varchar(100)";
            //}

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    ClienteId = 1,
                    Nome = "Flavio",
                    Sobrenome = "Spedaletti",
                    Email = "flavio@email.com",
                    DataCadastro = DateTime.Now,
                    Ativo = true
                });

            modelBuilder.Entity<Reclamacao>().HasData(
                new Reclamacao { ClienteId = 1, ReclamacaoId = 1, Descricao = "Internet lenta", Resolvida = false },
                new Reclamacao { ClienteId = 1, ReclamacaoId = 2, Descricao = "Sinal da TV caiu", Resolvida = true }
            );
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DataCadastro").IsModified = false;
            }

            return base.SaveChanges();
        }

    }
}
