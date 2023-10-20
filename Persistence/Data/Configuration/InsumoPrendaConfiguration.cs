using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class InsumoPrendaConfiguration : IEntityTypeConfiguration<InsumoPrenda>
    {
        public void Configure(EntityTypeBuilder<InsumoPrenda> builder){
    
            builder.ToTable("insumo_prenda");
    
          
            builder.HasOne(p => p.Insumo)
                .WithMany(p => p.InsumoPrendas)
                .HasForeignKey(p => p.IdInsumoFK);
            
            builder.HasOne(p => p.Prenda)
                .WithMany(p => p.InsumoPrendas)
                .HasForeignKey(p => p.IdPrendaFK);

            builder.HasData(
                new InsumoPrenda{IdInsumoFK = 1, IdPrendaFK = 1},
                new InsumoPrenda{IdInsumoFK = 2, IdPrendaFK = 1},
                new InsumoPrenda{IdInsumoFK = 4, IdPrendaFK = 1},
                new InsumoPrenda{IdInsumoFK = 3, IdPrendaFK = 2},
                new InsumoPrenda{IdInsumoFK = 4, IdPrendaFK = 2},
                new InsumoPrenda{IdInsumoFK = 1, IdPrendaFK = 3},
                new InsumoPrenda{IdInsumoFK = 2, IdPrendaFK = 3},
                new InsumoPrenda{IdInsumoFK = 3, IdPrendaFK = 4},
                new InsumoPrenda{IdInsumoFK = 4, IdPrendaFK = 4},
                new InsumoPrenda{IdInsumoFK = 4, IdPrendaFK = 5},
                new InsumoPrenda{IdInsumoFK = 2, IdPrendaFK = 5}
             
              
            );
        }
    }
}