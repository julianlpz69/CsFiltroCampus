using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class FormaPagoConfiguration : IEntityTypeConfiguration<FormaPago>
    {
        public void Configure(EntityTypeBuilder<FormaPago> builder){
    
            builder.ToTable("forma_pago");
    
          
            builder.Property(p => p.Descripcion)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

            builder.HasData(
                new FormaPago{Id = 1, Descripcion = "Efectivo"},
                new FormaPago{Id = 2, Descripcion = "Tarjeta"},
                new FormaPago{Id = 3, Descripcion = "En Especie"}
            );
        }
    }
}