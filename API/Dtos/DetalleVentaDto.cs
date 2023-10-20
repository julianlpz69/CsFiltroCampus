using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class DetalleVentaDto
    {
        public int Id {get; set;}
        public int Cantidad {get; set;}
        public double ValorUnit {get; set;}
        public int IdVentaFK {get; set;}
        public int IdTallaFk {get; set;}
        public int IdInventarioFK {get; set;}
        
    }
}