using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InsumoPrenda
    {
        public int IdInsumoFK {get; set;}
        public Insumo Insumo {get; set;}
        public int IdPrendaFK {get; set;}
        public Prenda Prenda {get; set;}
        public int Cantidad {get; set;}
    }
}