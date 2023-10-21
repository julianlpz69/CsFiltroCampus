using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder){
    
            builder.ToTable("detalle_venta");
    

            builder.HasOne(p => p.Talla)
                .WithMany(p => p.DetalleVentas)
                .HasForeignKey(p => p.IdTallaFk);

            builder.HasOne(p => p.Venta)
                .WithMany(p => p.DetalleVentas)
                .HasForeignKey(p => p.IdVentaFK);

            builder.HasOne(p => p.Inventario)
                .WithMany(p => p.DetalleVentas)
                .HasForeignKey(p => p.IdInventarioFK);

            builder.HasData(
                new DetalleVenta{Id = 1, Cantidad = 20, ValorUnit = 10000,  IdVentaFK = 1, IdTallaFk = 1, IdInventarioFK = 1 },
                new DetalleVenta{Id = 2, Cantidad = 22, ValorUnit = 20000,  IdVentaFK = 2, IdTallaFk = 2, IdInventarioFK = 2 },
                new DetalleVenta{Id = 3, Cantidad = 24, ValorUnit = 30000,  IdVentaFK = 3, IdTallaFk = 3, IdInventarioFK = 3 },
                new DetalleVenta{Id = 4, Cantidad = 25, ValorUnit = 10000,  IdVentaFK = 1, IdTallaFk = 1, IdInventarioFK = 1 },
                new DetalleVenta{Id = 5, Cantidad = 26, ValorUnit = 40000,  IdVentaFK = 4, IdTallaFk = 2, IdInventarioFK = 2 }
            );
        }
    }
}