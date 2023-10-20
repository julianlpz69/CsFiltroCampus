using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class OrdenDto
    {
        public int Id {get; set;}
        public DateOnly FechaOrden {get; set;}
        public int IdEmpleadoFk {get; set;}
        public int IdClienteFK {get; set;}
        public int IdEstadoFK {get; set;}
    }
}