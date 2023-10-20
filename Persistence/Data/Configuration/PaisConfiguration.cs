using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder){
    
            builder.ToTable("pais");
    
            builder.Property(p => p.NombrePais)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

            builder.HasData(
                new Pais{Id = 1, NombrePais = "Colombia"},
                new Pais{Id = 2, NombrePais = "Venezuela"}
            );
        }
    }
}