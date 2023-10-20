using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder){
    
            builder.ToTable("Estado");
    
            builder.Property(p => p.Descripcion)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

            builder.HasOne(p => p.TipoEstado)
                .WithMany(p => p.Estados)
                .HasForeignKey(p => p.IdTipoEstadoFK);


            builder.HasData(
                new Estado{Id = 1, Descripcion = "Finalizado", IdTipoEstadoFK = 1},
                new Estado{Id = 2, Descripcion = "Descansando", IdTipoEstadoFK = 2},
                new Estado{Id = 3, Descripcion = "No lo voy a hacer", IdTipoEstadoFK = 2},
                new Estado{Id = 4, Descripcion = "Vendido", IdTipoEstadoFK = 3}
            );

        }
    }
}