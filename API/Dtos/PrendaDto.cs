using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PrendaDto
    {
        public int Id {get; set;}
         public string IdPrenda {get; set;}
        public string NombrePrenda {get; set;}
        public double ValorUnitCop {get; set;}
        public double ValorUnitUsd {get; set;}
        public int IdEstadoFK {get; set;}
        public int IdTipoProteccionFK {get; set;}
        public int IdGneroFK {get; set;}
    }
}