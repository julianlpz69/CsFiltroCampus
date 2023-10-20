using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder){
    
            builder.ToTable("Empleado");
    
            builder.Property(p => p.NombreEmpleado)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(p => p.IdEmpleado)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();


            builder.HasOne(p => p.Municipio)
                .WithMany(p => p.Empleados)
                .HasForeignKey(p => p.IdMunicipioFk);

            builder.HasOne(p => p.Cargo)
                .WithMany(p => p.Empleados)
                .HasForeignKey(p => p.IdCargoFK);

            builder.HasData(
                new Empleado{Id = 1, NombreEmpleado = "Ozuna", FechaIngreso = DateOnly.Parse("2023-11-21"), IdCargoFK = 1, IdEmpleado = "", IdMunicipioFk = 1},
                new Empleado{Id = 2, NombreEmpleado = "Romeo Santos", FechaIngreso = DateOnly.Parse("2023-11-21"), IdCargoFK = 1, IdEmpleado = "", IdMunicipioFk = 2},
                new Empleado{Id = 3, NombreEmpleado = "Karol G", FechaIngreso = DateOnly.Parse("2023-11-21"), IdCargoFK = 2, IdEmpleado = "", IdMunicipioFk = 3},
                new Empleado{Id = 4, NombreEmpleado = "Luis Fonsi", FechaIngreso = DateOnly.Parse("2023-11-21"), IdCargoFK = 2, IdEmpleado = "", IdMunicipioFk = 1},
                new Empleado{Id = 5, NombreEmpleado = "Drake", FechaIngreso = DateOnly.Parse("2023-11-21"), IdCargoFK = 3, IdEmpleado = "", IdMunicipioFk = 2}
            );
    
        }
    }
}