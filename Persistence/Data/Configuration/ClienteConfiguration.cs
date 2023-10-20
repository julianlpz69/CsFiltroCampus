using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder){
    
            builder.ToTable("Cliente");
    
            builder.Property(p => p.NombreCliente)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(p => p.CodigoCliente)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();


            builder.HasOne(p => p.TipoPersona)
                .WithMany(p => p.Clientes)
                .HasForeignKey(p => p.IdTipoPersonaFK);

            builder.HasOne(p => p.Municipio)
                .WithMany(p => p.Clientes)
                .HasForeignKey(p => p.IdMunicipioFk);


            builder.HasData(
                new Cliente{Id = 1, NombreCliente = "Pedro David", CodigoCliente = "1912", FechaRegistro = DateOnly.Parse("2023-12-21"), IdMunicipioFk = 1, IdTipoPersonaFK = 1},
                new Cliente{Id = 2, NombreCliente = "Jose Jose", CodigoCliente = "1923", FechaRegistro = DateOnly.Parse("2023-12-23"), IdMunicipioFk = 2, IdTipoPersonaFK = 1},
                new Cliente{Id = 3, NombreCliente = "Chayan", CodigoCliente = "1920", FechaRegistro = DateOnly.Parse("2023-12-25"), IdMunicipioFk = 3, IdTipoPersonaFK = 1},
                new Cliente{Id = 4, NombreCliente = "Luis Miguel", CodigoCliente = "1921", FechaRegistro = DateOnly.Parse("2023-12-26"), IdMunicipioFk = 1, IdTipoPersonaFK = 1},
                new Cliente{Id = 5, NombreCliente = "Don Omar", CodigoCliente = "1934", FechaRegistro = DateOnly.Parse("2023-12-29"), IdMunicipioFk = 1, IdTipoPersonaFK = 1}
                

            );
        }
    }
}