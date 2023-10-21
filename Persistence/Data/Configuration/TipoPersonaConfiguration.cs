using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TipoPersonaConfiguration : IEntityTypeConfiguration<TipoPersona>
    {
        public void Configure(EntityTypeBuilder<TipoPersona> builder){
    
            builder.ToTable("tipo_persona");
    
            builder.Property(p => p.NombreTipoPersona)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

            builder.HasData(
                new TipoPersona{Id = 1, NombreTipoPersona = "Persona Natural"},
                new TipoPersona{Id = 2, NombreTipoPersona = "Persona Juridica"}
            );
        }
    }
}