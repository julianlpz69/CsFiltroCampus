using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class DatosUsuarioDto
    {
        public string Mensaje { get; set; }
        public bool EstadoAutenticado { get; set; }
        public string NombreUsuario { get; set; }
        public string CorreoUsuario { get; set; }
        public List<string> UsuarioRoles { get; set; }
        public string UsuarioToken { get; set; }
        [JsonIgnore]
        public string RefreshToken {get; set;}
        public DateTime RefreshTokenExpiry {get; set;}
    }
}