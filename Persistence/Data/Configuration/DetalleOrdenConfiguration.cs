using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DetalleOrdenConfiguration : IEntityTypeConfiguration<DetalleOrden>
    {
        public void Configure(EntityTypeBuilder<DetalleOrden> builder){
    
            builder.ToTable("detalle_orden");
    
            builder.HasOne(p => p.Color)
                .WithMany(p => p.DetalleOrdenes)
                .HasForeignKey(p => p.IdColorFK);

            builder.HasOne(p => p.Orden)
                .WithMany(p => p.DetalleOrdenes)
                .HasForeignKey(p => p.IdOrdenFK);


            builder.HasOne(p => p.Prenda)
                .WithMany(p => p.DetalleOrdenes)
                .HasForeignKey(p => p.IdPrendaFK);

            builder.HasOne(p => p.Estado)
                .WithMany(p => p.DetalleOrdenes)
                .HasForeignKey(p => p.IdEstadoFK);

            builder.HasData(
                new DetalleOrden{Id = 1, CantidadProducida = 20, IdColorFK = 1, IdEstadoFK = 1, CatidadProducir = 100, IdOrdenFK = 1, IdPrendaFK = 1 },
                new DetalleOrden{Id = 2, CantidadProducida = 22, IdColorFK = 2, IdEstadoFK = 2, CatidadProducir = 80, IdOrdenFK = 2, IdPrendaFK = 2 },
                new DetalleOrden{Id = 3, CantidadProducida = 24, IdColorFK = 3, IdEstadoFK = 1, CatidadProducir = 70, IdOrdenFK = 3, IdPrendaFK = 3 },
                new DetalleOrden{Id = 4, CantidadProducida = 25, IdColorFK = 1, IdEstadoFK = 2, CatidadProducir = 50, IdOrdenFK = 1, IdPrendaFK = 1 },
                new DetalleOrden{Id = 5, CantidadProducida = 26, IdColorFK = 4, IdEstadoFK = 1, CatidadProducir = 30, IdOrdenFK = 2, IdPrendaFK = 4 }
            );
    
        }
    }
}