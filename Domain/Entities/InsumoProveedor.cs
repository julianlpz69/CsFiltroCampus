using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InsumoProveedor
    {
        public int IdInsumoFK {get; set;}
        public Insumo Insumo {get; set;}
        public int IdProveedorFK {get; set;}
        public Proveedor Proveedor {get; set;}
       
    }
}