using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder){
    
            builder.ToTable("Empresa");

            builder.Property(p => p.NitEmpresa)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(p => p.RazonSocial)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();


            builder.Property(p => p.RepresentanteLegal)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();


            builder.HasOne(p => p.Municipio)
                .WithMany(p => p.Empresas)
                .HasForeignKey(p => p.IdMunicipioFk);
            

            builder.HasData(
                new Empresa{Id = 1, FechaCreacion = DateOnly.Parse("2003-11-21"), IdMunicipioFk = 1, NitEmpresa = "10023123", RazonSocial = "Sin Animo de Lucro", RepresentanteLegal = "Suits"},
                new Empresa{Id = 2, FechaCreacion = DateOnly.Parse("2013-11-21"), IdMunicipioFk = 2, NitEmpresa = "1002023", RazonSocial = "Ganar Plata", RepresentanteLegal = "Suits"},
                new Empresa{Id = 3, FechaCreacion = DateOnly.Parse("2002-11-21"), IdMunicipioFk = 3, NitEmpresa = "1006969", RazonSocial = "Sin Animo de Lucro", RepresentanteLegal = "Suits"},
                new Empresa{Id = 4, FechaCreacion = DateOnly.Parse("2005-11-21"), IdMunicipioFk = 1, NitEmpresa = "1005544", RazonSocial = "Ganar Plata", RepresentanteLegal = "Suits"}
            );
          
    
        }
    }
}