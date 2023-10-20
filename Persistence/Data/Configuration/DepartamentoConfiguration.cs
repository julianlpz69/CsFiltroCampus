using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder){
    
            builder.ToTable("Departamento");
    
          
            builder.Property(p => p.NombreDepartamento)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();


            builder.HasOne(p => p.Pais)
                .WithMany(p => p.Departamentos)
                .HasForeignKey(p => p.IdPaisFK);

            builder.HasData(
                new Departamento{Id = 1, NombreDepartamento = "Santander", IdPaisFK = 1},
                new Departamento{Id = 2, NombreDepartamento = "Cundinamarca", IdPaisFK = 1},
                new Departamento{Id = 3, NombreDepartamento = "Carabobo", IdPaisFK = 2},
                new Departamento{Id = 4, NombreDepartamento = "Caracas", IdPaisFK = 2}
            );
        }   
    }
}