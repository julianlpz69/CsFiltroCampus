using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class VentaConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder){
    
            builder.ToTable("Venta");
    
            builder.HasOne(p => p.Empleado)
                .WithMany(p => p.Ventas)
                .HasForeignKey(p => p.IdEmpleadoFK);


            builder.HasOne(p => p.FormaPago)
                .WithMany(p => p.Ventas)
                .HasForeignKey(p => p.IdFormaPago);

            builder.HasOne(p => p.Cliente)
                .WithMany(p => p.Ventas)
                .HasForeignKey(p => p.IdClienteFK);
            
            builder.HasData(
                new Venta{Id = 1, IdClienteFK = 1, IdEmpleadoFK = 1, IdFormaPago = 1, FechaVenta = DateOnly.Parse("2003-11-21") },
                new Venta{Id = 2, IdClienteFK = 2, IdEmpleadoFK = 2, IdFormaPago = 1, FechaVenta = DateOnly.Parse("2003-11-25") },
                new Venta{Id = 3, IdClienteFK = 3, IdEmpleadoFK = 3, IdFormaPago = 2, FechaVenta = DateOnly.Parse("2003-11-24") },
                new Venta{Id = 4, IdClienteFK = 4, IdEmpleadoFK = 1, IdFormaPago = 2, FechaVenta = DateOnly.Parse("2003-11-26") },
                new Venta{Id = 5, IdClienteFK = 1, IdEmpleadoFK = 4, IdFormaPago = 3, FechaVenta = DateOnly.Parse("2003-11-27") ,}
            );
        }
    }
}