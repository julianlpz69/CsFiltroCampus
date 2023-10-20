using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TipoEstadoConfiguration : IEntityTypeConfiguration<TipoEstado>
    {
        public void Configure(EntityTypeBuilder<TipoEstado> builder){
    
            builder.ToTable("tipo_estado");
    
          
            builder.Property(p => p.Descripcion)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

            builder.HasData(
                new TipoEstado{Id = 1, Descripcion = "Finalizado"},
                new TipoEstado{Id = 2, Descripcion = "En Produccion"},
                new TipoEstado{Id = 3, Descripcion = "Vendido"}
            );
        }
    }
} 