using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmpleadoDto
    {
        public int Id {get; set;}
        public string IdEmpleado {get; set;}
        public string NombreEmpleado {get; set;}
        public DateOnly FechaIngreso {get; set;}
        public int IdCargoFK {get; set;}
        public int IdMunicipioFk {get; set;}
        
    }
}