using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder){
    
            builder.ToTable("Genero");
    
            builder.Property(p => p.Descripcion)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

            builder.HasData(
                new Genero{Id = 1, Descripcion = "Masculino"},
                new Genero{Id = 2, Descripcion = "Femenino"},
                new Genero{Id = 3, Descripcion = "Unisex"}
            );
        }
    }
}