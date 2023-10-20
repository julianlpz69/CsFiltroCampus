using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetalleOrden : BaseEntity
    {
        public int CatidadProducir {get; set;}
        public int CantidadProducida {get; set;}
        public int IdOrdenFK {get; set;}
        public Orden Orden {get; set;}
        public int IdPrendaFK {get; set;}
        public Prenda Prenda {get; set;}
        public int IdColorFK {get; set;}
        public Colors Color {get; set;}
        public int IdEstadoFK {get; set;}
        public Estado Estado {get; set;}
    }
}