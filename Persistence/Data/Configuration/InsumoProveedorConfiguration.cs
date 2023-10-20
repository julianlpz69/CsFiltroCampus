using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class InsumoProveedorConfiguration : IEntityTypeConfiguration<InsumoProveedor>
    {
        public void Configure(EntityTypeBuilder<InsumoProveedor> builder){
    
            builder.ToTable("insumo_proveedor");
    
          
            builder.HasOne(p => p.Insumo)
                .WithMany(p => p.InsumoProveedores)
                .HasForeignKey(p => p.IdInsumoFK);
            
            builder.HasOne(p => p.Proveedor)
                .WithMany(p => p.InsumoProveedores)
                .HasForeignKey(p => p.IdProveedorFK);


            builder.HasData(
                new InsumoProveedor{IdInsumoFK = 1, IdProveedorFK = 1},
                new InsumoProveedor{IdInsumoFK = 2, IdProveedorFK = 1},
                new InsumoProveedor{IdInsumoFK = 4, IdProveedorFK = 1},
                new InsumoProveedor{IdInsumoFK = 3, IdProveedorFK = 2},
                new InsumoProveedor{IdInsumoFK = 4, IdProveedorFK = 2},
                new InsumoProveedor{IdInsumoFK = 1, IdProveedorFK = 3},
                new InsumoProveedor{IdInsumoFK = 2, IdProveedorFK = 3},
                new InsumoProveedor{IdInsumoFK = 3, IdProveedorFK = 4},
                new InsumoProveedor{IdInsumoFK = 4, IdProveedorFK = 4},
                new InsumoProveedor{IdInsumoFK = 4, IdProveedorFK = 5},
                new InsumoProveedor{IdInsumoFK = 2, IdProveedorFK = 5}
             
              
            );
        }
    }
}