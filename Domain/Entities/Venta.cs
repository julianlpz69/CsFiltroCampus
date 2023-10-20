using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Venta : BaseEntity
    {
        public DateOnly FechaVenta {get; set;}
        public int IdEmpleadoFK {get; set;}
        public Empleado Empleado {get; set;}
        public int IdClienteFK {get; set;}
        public Cliente Cliente {get; set;}
        public int IdFormaPago {get; set;}
        public FormaPago FormaPago {get; set;}
        public ICollection<DetalleVenta> DetalleVentas {get; set;}

    }
}