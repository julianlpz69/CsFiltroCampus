using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetalleVenta : BaseEntity
    {
        public int Cantidad {get; set;}
        public double ValorUnit {get; set;}
        public int IdVentaFK {get; set;}
        public Venta Venta {get; set;}
        public int IdTallaFk {get; set;}
        public Talla Talla {get; set;}
        public int IdInventarioFK {get; set;}
        public Inventario Inventario {get; set;}
    }
}