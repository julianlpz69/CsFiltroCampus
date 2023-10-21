using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class VentaEmpleadoDto
    {
        public int Id {get; set;}
        public DateOnly FechaVenta {get; set;}
        public EmpleadoDto Empleado {get; set;}
        public ICollection<DetalleVentaDto> DetalleVentas {get; set;}
    }
}