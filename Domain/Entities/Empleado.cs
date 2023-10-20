using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Empleado : BaseEntity
    {
        public string IdEmpleado {get; set;}
        public string NombreEmpleado {get; set;}
        public DateOnly FechaIngreso {get; set;}
        public int IdCargoFK {get; set;}
        public Cargo Cargo {get; set;}
        public int IdMunicipioFk {get; set;}
        public Municipio Municipio {get; set;}
        public ICollection<Orden> Ordenes {get; set;}
        public ICollection<Venta> Ventas {get; set;}


    }
}