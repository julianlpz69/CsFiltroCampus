using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TipoProteccionConfiguration : IEntityTypeConfiguration<TipoProteccion>
    {
        public void Configure(EntityTypeBuilder<TipoProteccion> builder){
    
            builder.ToTable("tipo_proteccion");
    
            builder.Property(p => p.Descripcion)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

            builder.HasData(
                new TipoProteccion{Id =1, Descripcion = "No Proteje"},
                new TipoProteccion{Id =2, Descripcion = "Anti Fuego"},
                new TipoProteccion{Id =3, Descripcion = "Anti Balas"},
                new TipoProteccion{Id =4, Descripcion = "Anti Arañasos"}
            );
    
        }
    }
}