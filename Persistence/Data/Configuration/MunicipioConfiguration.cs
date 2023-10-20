using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class MunicipioConfiguration : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder){
    
            builder.ToTable("municipio");
    
            builder.Property(p => p.NombreMunicipio)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();


            builder.HasOne(p => p.Departamento)
                .WithMany(p => p.Municipios)
                .HasForeignKey(p => p.IdDepartamentoFK);

            builder.HasData(
                new Municipio{Id = 1, NombreMunicipio = "Bucaramanga", IdDepartamentoFK = 1},
                new Municipio{Id = 2, NombreMunicipio = "Giron", IdDepartamentoFK = 1},
                new Municipio{Id = 3, NombreMunicipio = "Floridablanca", IdDepartamentoFK = 1}
              
            );
    
        }
    }
}