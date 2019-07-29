using FS.DDDTop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FS.DDDTop.Infra.Data.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //a convenção do efcore não tem pluralize
            //modelBuilder.Entity<Cliente>().ToTable("Cliente");

            //remove comportamente de cascade delete (TALVEZ)
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //configura os campos string para varchar(100), mas o problema é que sobrescreve as data annotations da entidade
            //foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
            //{
            //    property.Relational().ColumnType = "varchar(100)";
            //}

            //modelBuilder.ApplyConfiguration(new ProductConfiguration());

        }
    }

    //public class ProductConfiguration : IEntityTypeConfiguration<Product>
    //{
    //    public void Configure(EntityTypeBuilder<Product> builder)
    //    {
    //        builder.HasKey(x => x.ProductID);
    //        builder.HasOne(e => e.Details).WithOne(o => o.Product).HasForeignKey<ProductDetail>(e => e.ProductID);
    //        builder.Property(x => x.Cost).HasColumnName("StandardCost");
    //        builder.HasQueryFilter(o => o.Cost > 0);
    //        builder.ToTable("Product");
    //    }
    //}
}
