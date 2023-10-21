using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder){
    
            builder.ToTable("Proveedor");
    
            builder.Property(p => p.NitProveedor)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();


            builder.Property(p => p.NombreProveedor)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

            


            builder.HasOne(p => p.TipoPersona)
                .WithMany(p => p.Proveedores)
                .HasForeignKey(p => p.IdTipoPersonaFK);

            builder.HasOne(p => p.Municipio)
                .WithMany(p => p.Proveedores)
                .HasForeignKey(p => p.IdMunicipioFk);

            builder.HasData(
              new Proveedor  {Id = 1, IdMunicipioFk = 1, IdTipoPersonaFK = 1, NitProveedor = "1002312", NombreProveedor = "Ropa la 15"},
              new Proveedor  {Id = 2, IdMunicipioFk = 2, IdTipoPersonaFK = 2, NitProveedor = "1007766", NombreProveedor = "LA ropera"},
              new Proveedor  {Id = 3, IdMunicipioFk = 3, IdTipoPersonaFK = 1, NitProveedor = "1005432", NombreProveedor = "La ropita"},
              new Proveedor  {Id = 4, IdMunicipioFk = 1, IdTipoPersonaFK = 2, NitProveedor = "1001212", NombreProveedor = "Ropa Masx"},
              new Proveedor  {Id = 5, IdMunicipioFk = 2, IdTipoPersonaFK = 2, NitProveedor = "1006965", NombreProveedor = "Guchi"}
            );
        }
    }
}