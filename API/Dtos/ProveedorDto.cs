using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProveedorDto
    {
        public int Id {get; set;}
        public int NitProveedor {get; set;}
        public string NombreProveedor {get; set;}
        public int IdTipoPersonaFK {get; set;}
        public int IdMunicipioFk {get; set;}
        
    }
}