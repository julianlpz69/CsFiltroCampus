using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder){
    
            builder.ToTable("cargo");
    
            builder.Property(p => p.Descripcion)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();


            builder.HasData(
                new Cargo{Id = 1, Descripcion = "Limpiador", SueldoBase = 50000},
                new Cargo{Id = 2, Descripcion = "Estilista", SueldoBase = 100000},
                new Cargo{Id = 3, Descripcion = "Cajera", SueldoBase = 70000}

            );
    
        }
    }
} 