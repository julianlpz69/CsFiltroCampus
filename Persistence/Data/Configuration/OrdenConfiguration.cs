using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder){
    
            builder.ToTable("Orden");

            builder.HasOne(p => p.Cliente)
                .WithMany(p => p.Ordenes)
                .HasForeignKey(p => p.IdClienteFK);

            builder.HasOne(p => p.Empleado)
                .WithMany(p => p.Ordenes)
                .HasForeignKey(p => p.IdEmpleadoFk);


            builder.HasOne(p => p.Estado)
                .WithMany(p => p.Ordenes)
                .HasForeignKey(p => p.IdEstadoFK);
          
            builder.HasData(
                new Orden{Id = 1, FechaOrden = DateOnly.Parse("2003-11-21"), IdClienteFK = 1, IdEmpleadoFk = 1, IdEstadoFK = 3 },
                new Orden{Id = 2, FechaOrden = DateOnly.Parse("2003-11-25"), IdClienteFK = 2, IdEmpleadoFk = 1, IdEstadoFK = 3 },
                new Orden{Id = 3, FechaOrden = DateOnly.Parse("2003-11-26"), IdClienteFK = 3, IdEmpleadoFk = 2, IdEstadoFK = 3 },
                new Orden{Id = 4, FechaOrden = DateOnly.Parse("2003-11-27"), IdClienteFK = 4, IdEmpleadoFk = 3, IdEstadoFK = 3 },
                new Orden{Id = 5, FechaOrden = DateOnly.Parse("2003-11-28"), IdClienteFK = 5, IdEmpleadoFk = 4, IdEstadoFK = 3 }
            );
        }
    }
}