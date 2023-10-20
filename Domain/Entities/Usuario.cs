using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string NombreUsuario { get; set; }
        public string CorreoUsuario { get; set;}
        public string ClaveUsuario { get; set;}
        public ICollection<Rol> Rols { get; set; } = new HashSet<Rol>();
        public ICollection<UsuarioRol> UsuarioRols { get; set;}
        public ICollection<RefreshToken> RefreshTokens { get; set;}
    }
}