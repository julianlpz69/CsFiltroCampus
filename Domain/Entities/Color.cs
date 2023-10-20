using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Colors : BaseEntity
    {
        public string Descripcion {get; set;}
        public ICollection<DetalleOrden> DetalleOrdenes {get; set;}
    }
}