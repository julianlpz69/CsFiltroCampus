using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class OrdenSeviciolDto
    {
        public DateOnly FechaOrden {get; set;}
        public int IdClienteFK {get; set;}
        public ClienteDto Cliente {get; set;}
        public ICollection<DetalleOrdenDto> DetalleOrdenes {get; set;}
    }
}