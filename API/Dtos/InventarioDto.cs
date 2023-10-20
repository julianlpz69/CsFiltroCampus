using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class InventarioDto
    {
        public int Id {get; set;}
        public string CodigoInventario {get; set;}
        public double ValorVtaCop {get; set;}
        public double ValorVtaUsd {get; set;}
        public int IdPredaFK {get; set;}
    }
}