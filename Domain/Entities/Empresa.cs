using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Empresa : BaseEntity
    {
        public string NitEmpresa {get; set;}
        public string RazonSocial {get; set;}
        public string RepresentanteLegal {get; set;}
        public DateOnly FechaCreacion {get; set;}
        public int IdMunicipioFk {get; set;}
        public Municipio Municipio {get; set;}
    }
}