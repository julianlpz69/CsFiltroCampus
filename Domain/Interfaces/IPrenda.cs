using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPrenda : IGenericRepository<Prenda>
    {
        Task<IEnumerable<Prenda>> EstadoProduccion(int Numero);
        Task<IEnumerable<IGrouping<TipoProteccion,Prenda>>> TipoProteccion();
        Task<IEnumerable<Prenda>> PrendasInsumos();
        
    }
}