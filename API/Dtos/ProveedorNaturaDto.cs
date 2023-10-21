using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProveedorNaturaDto
    {
        public int Id {get; set;}
        public int NitProveedor {get; set;}
        public string NombreProveedor {get; set;}
        public string NombreTipoPersona {get; set;}
    }
}