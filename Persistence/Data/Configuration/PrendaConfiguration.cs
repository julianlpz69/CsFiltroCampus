using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PrendaConfiguration : IEntityTypeConfiguration<Prenda>
    {
        public void Configure(EntityTypeBuilder<Prenda> builder){
    
            builder.ToTable("Prenda");


            builder.Property(p => p.NombrePrenda)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();


            builder.Property(p => p.IdPrenda)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();


            builder.HasOne(p => p.Estado)
                .WithMany(p => p.Prendas)
                .HasForeignKey(p => p.IdEstadoFK);

            builder.HasOne(p => p.TipoProteccion)
                .WithMany(p => p.Prendas)
                .HasForeignKey(p => p.IdTipoProteccionFK);

            builder.HasOne(p => p.Genero)
                .WithMany(p => p.Prendas)
                .HasForeignKey(p => p.IdGneroFK);
    

            builder.HasData(
                new Prenda{Id = 1, NombrePrenda = "Camiceta", ValorUnitCop = 50000, ValorUnitUsd = 10, IdPrenda = "1002131", IdEstadoFK = 1, IdGneroFK = 1, IdTipoProteccionFK = 1},
                new Prenda{Id = 2, NombrePrenda = "Pantalon", ValorUnitCop = 100000, ValorUnitUsd = 20, IdPrenda = "100231", IdEstadoFK = 1, IdGneroFK = 2, IdTipoProteccionFK = 2},
                new Prenda{Id = 3, NombrePrenda = "Vestido", ValorUnitCop = 120000, ValorUnitUsd = 25, IdPrenda = "100213", IdEstadoFK = 2, IdGneroFK = 1, IdTipoProteccionFK = 3},
                new Prenda{Id = 4, NombrePrenda = "Gorra", ValorUnitCop = 30000, ValorUnitUsd = 7, IdPrenda = "200132", IdEstadoFK = 1, IdGneroFK = 2, IdTipoProteccionFK = 1},
                new Prenda{Id = 5, NombrePrenda = "Sudadera", ValorUnitCop = 40000, ValorUnitUsd = 9, IdPrenda = "2032132", IdEstadoFK = 2, IdGneroFK = 1, IdTipoProteccionFK = 2}

                
              
            );
    
        }
    }
}