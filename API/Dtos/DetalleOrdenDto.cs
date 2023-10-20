using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class DetalleOrdenDto
    {
        public int Id {get; set;}
         public int CatidadProducir {get; set;}
        public int CantidadProducida {get; set;}
        public int IdOrdenFK {get; set;}
        public int IdPrendaFK {get; set;}
        public int IdColorFK {get; set;}
        public int IdEstadoFK {get; set;}
        
    }
}