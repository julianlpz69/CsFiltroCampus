using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Prenda : BaseEntity
    {
        public string IdPrenda {get; set;}
        public string NombrePrenda {get; set;}
        public double ValorUnitCop {get; set;}
        public double ValorUnitUsd {get; set;}
        public int IdEstadoFK {get; set;}
        public Estado Estado {get; set;}
        public int IdTipoProteccionFK {get; set;}
        public TipoProteccion TipoProteccion {get; set;}
        public int IdGneroFK {get; set;}
        public Genero Genero {get; set;}
        public ICollection<DetalleOrden> DetalleOrdenes {get; set;}
        public ICollection<InsumoPrenda> InsumoPrendas {get; set;}
        public ICollection<Inventario> Inventarios {get; set;}

    }
}