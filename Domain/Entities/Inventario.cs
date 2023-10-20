using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Inventario : BaseEntity
    {
        public string CodigoInventario {get; set;}
        public double ValorVtaCop {get; set;}
        public double ValorVtaUsd {get; set;}
        public int IdPredaFK {get; set;}
        public Prenda Prenda {get; set;}
        public ICollection<InventarioTalla> InventarioTallas {get; set;}
        public ICollection<DetalleVenta> DetalleVentas {get; set;}
    }
}