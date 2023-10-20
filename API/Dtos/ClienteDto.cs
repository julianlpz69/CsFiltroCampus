using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClienteDto
    {
        public int Id {get; set;}
        public string CodigoCliente {get; set;}
        public string NombreCliente {get; set;}
        public DateOnly FechaRegistro {get; set;}
        public int IdTipoPersonaFK {get; set;}
        public int IdMunicipioFk {get; set;}
        
    }
}