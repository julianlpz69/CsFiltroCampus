using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ColorConfiguration : IEntityTypeConfiguration<Colors>
    {
        public void Configure(EntityTypeBuilder<Colors> builder){
    
            builder.ToTable("Color");
    
            builder.Property(p => p.Descripcion)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

            builder.HasData(
                new Colors{Id = 1, Descripcion = "Rosa"},
                new Colors{Id = 2, Descripcion = "Magenta"},
                new Colors{Id = 3, Descripcion = "Naranja"},
                new Colors{Id = 4, Descripcion = "Rojo"},
                new Colors{Id = 5, Descripcion = "Azul"}
            );
        }
    }
}