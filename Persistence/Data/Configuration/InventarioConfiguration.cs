using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder){
    
            builder.ToTable("Inventario");
    
            builder.Property(p => p.CodigoInventario)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();


            builder.HasOne(p => p.Prenda)
                .WithMany(p => p.Inventarios)
                .HasForeignKey(p => p.IdPredaFK);

            builder.HasData(
                new Inventario{Id = 1, CodigoInventario = "12332", ValorVtaCop = 200000, ValorVtaUsd = 20, IdPredaFK = 1 },
                new Inventario{Id = 2, CodigoInventario = "1234", ValorVtaCop = 220000, ValorVtaUsd = 22, IdPredaFK = 2 },
                new Inventario{Id = 3, CodigoInventario = "4321", ValorVtaCop = 240000, ValorVtaUsd = 24, IdPredaFK = 3 },
                new Inventario{Id = 4, CodigoInventario = "54231", ValorVtaCop = 250000, ValorVtaUsd = 25, IdPredaFK = 4 },
                new Inventario{Id = 5, CodigoInventario = "1235", ValorVtaCop = 260000, ValorVtaUsd = 26, IdPredaFK = 5 }
            );
        }
    }
}