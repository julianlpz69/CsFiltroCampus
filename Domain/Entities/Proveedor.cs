using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Proveedor : BaseEntity
    {
        public string NitProveedor {get; set;}
        public string NombreProveedor {get; set;}
        public int IdTipoPersonaFK {get; set;}
        public TipoPersona TipoPersona {get; set;}
        public int IdMunicipioFk {get; set;}
        public Municipio Municipio {get; set;}
        public ICollection<InsumoProveedor> InsumoProveedores {get; set;}
        
    }
}