using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder){
    
              builder.ToTable("user");

            builder.Property(p => p.NombreUsuario)
            .HasColumnName("username")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();


            builder.Property(p => p.ClaveUsuario)
           .HasColumnName("password")
           .HasColumnType("varchar")
           .HasMaxLength(255)
           .IsRequired();

            builder.Property(p => p.CorreoUsuario)
            .HasColumnName("email")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

            builder
           .HasMany(p => p.Rols)
           .WithMany(r => r.Usuarios)
           .UsingEntity<UsuarioRol>(

               j => j
               .HasOne(pt => pt.Rol)
               .WithMany(t => t.UsuariosRols)
               .HasForeignKey(ut => ut.IdRolFK),


               j => j
               .HasOne(et => et.Usuario)
               .WithMany(et => et.UsuarioRols)
               .HasForeignKey(el => el.IdUsuarioFK),

               j =>
               {
                   j.ToTable("userRol");
                   j.HasKey(t => new { t.IdUsuarioFK, t.IdRolFK });

               });

            builder.HasMany(p => p.RefreshTokens)
            .WithOne(p => p.Usuario)
            .HasForeignKey(p => p.IdUsuarioFK);

        
        
    
        }
    }
}