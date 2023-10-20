using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TipoPersona : BaseEntity
    {
        public string NombreTipoPersona {get; set;}
        public ICollection<Proveedor> Proveedores {get; set;}
        public ICollection<Cliente> Clientes {get; set;}
    }
}