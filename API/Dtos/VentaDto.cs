using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class VentaDto
    {
        public int Id {get; set;}
         public DateOnly FechaVenta {get; set;}
        public int IdEmpleadoFK {get; set;}
        public int IdClienteFK {get; set;}
        public int IdFormaPago {get; set;}
 
    }
}