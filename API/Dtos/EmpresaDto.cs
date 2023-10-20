using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmpresaDto
    {
        public int Id {get; set;}
        public string NitEmpresa {get; set;}
        public string RazonSocial {get; set;}
        public string RepresentanteLegal {get; set;}
        public DateOnly FechaCreacion {get; set;}
        public int IdMunicipioFk {get; set;}
    }
}