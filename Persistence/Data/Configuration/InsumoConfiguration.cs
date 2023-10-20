using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
    {
        public void Configure(EntityTypeBuilder<Insumo> builder){
    
            builder.ToTable("Insumo");
    
            builder.Property(p => p.NombreInsumo)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();


            builder.HasData(
                new Insumo{Id = 1, NombreInsumo = "Tela", ValorUnit = 10000, StockMax = 100, StockMin = 20},
                new Insumo{Id = 2, NombreInsumo = "Botones", ValorUnit = 5000, StockMax = 100, StockMin = 20},
                new Insumo{Id = 3, NombreInsumo = "Aguja", ValorUnit = 2000, StockMax = 100, StockMin = 20},
                new Insumo{Id = 4, NombreInsumo = "Pintura", ValorUnit = 15000, StockMax = 100, StockMin = 20}
                
              
            );
            
    
        }
    }
}