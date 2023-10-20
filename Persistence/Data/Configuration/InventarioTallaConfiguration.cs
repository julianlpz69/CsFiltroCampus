using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class InventarioTallaConfiguration : IEntityTypeConfiguration<InventarioTalla>
    {
        public void Configure(EntityTypeBuilder<InventarioTalla> builder){
    
            builder.ToTable("inventario_talla");
    
          
            builder.HasOne(p => p.Inventario)
                    .WithMany(p => p.InventarioTallas)
                    .HasForeignKey(p => p.IdInventarioFK);
                
            builder.HasOne(p => p.Talla)
                .WithMany(p => p.InventarioTallas)
                .HasForeignKey(p => p.IdTallaFk);


            builder.HasData(
                new InventarioTalla{IdTallaFk = 1, IdInventarioFK = 1},
                new InventarioTalla{IdTallaFk = 2, IdInventarioFK = 1},
                new InventarioTalla{IdTallaFk = 4, IdInventarioFK = 1},
                new InventarioTalla{IdTallaFk = 3, IdInventarioFK = 2},
                new InventarioTalla{IdTallaFk = 4, IdInventarioFK = 2},
                new InventarioTalla{IdTallaFk = 1, IdInventarioFK = 3},
                new InventarioTalla{IdTallaFk = 2, IdInventarioFK = 3},
                new InventarioTalla{IdTallaFk = 3, IdInventarioFK = 4},
                new InventarioTalla{IdTallaFk = 4, IdInventarioFK = 4},
                new InventarioTalla{IdTallaFk = 4, IdInventarioFK = 5},
                new InventarioTalla{IdTallaFk = 2, IdInventarioFK = 5}
             
              
            );
        }
    }
}