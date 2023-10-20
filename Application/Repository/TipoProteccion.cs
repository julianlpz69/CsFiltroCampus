using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class TipoProteccionRepository : GenericRepository<TipoProteccion>, ITipoProteccion
    {
        private readonly TiendaRopaDBcontext _context;

        public TipoProteccionRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}