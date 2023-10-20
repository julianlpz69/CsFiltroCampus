using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TallaConfiguration : IEntityTypeConfiguration<Talla>
    {
        public void Configure(EntityTypeBuilder<Talla> builder){
    
            builder.ToTable("Talla");
    
            builder.Property(p => p.Descripcion)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

            builder.HasData(
                new Talla{Id = 1, Descripcion = "S"},
                new Talla{Id = 2, Descripcion = "L"},
                new Talla{Id = 3, Descripcion = "XL"},
                new Talla{Id = 4, Descripcion = "XLL"}
            );
        }
    }
}