using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PrendaProduccionDto
    {
        public string IdPrenda {get; set;}
        public string NombrePrenda {get; set;}
        public double ValorUnitCop {get; set;}
        public string EstadoProduccion {get; set;}
    }
}