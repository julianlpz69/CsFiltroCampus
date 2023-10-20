using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string CodigoCliente {get; set;}
        public string NombreCliente {get; set;}
        public DateOnly FechaRegistro {get; set;}
        public int IdTipoPersonaFK {get; set;}
        public TipoPersona TipoPersona {get; set;}
        public int IdMunicipioFk {get; set;}
        public Municipio Municipio {get; set;}
        public ICollection<Venta> Ventas {get; set;}
        public ICollection<Orden> Ordenes {get; set;}
    }
}