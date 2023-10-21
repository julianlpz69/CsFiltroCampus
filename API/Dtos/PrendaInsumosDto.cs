using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class PrendaInsumosDto
    {
        public string IdPrenda {get; set;}
        public string NombrePrenda {get; set;}
        public double ValorRealizarPrenda {get; set;}
        
    
    }
}