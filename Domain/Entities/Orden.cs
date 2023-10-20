using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    public class Orden : BaseEntity
    {
        
        public DateOnly FechaOrden {get; set;}
        public int IdEmpleadoFk {get; set;}
        public Empleado Empleado {get; set;}
        public int IdClienteFK {get; set;}
        public Cliente Cliente {get; set;}
        public int IdEstadoFK {get; set;}
        public Estado Estado {get; set;}
        public ICollection<DetalleOrden> DetalleOrdenes {get; set;}
        
    }
}