using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class TipoEstadoRepository : GenericRepository<TipoEstado>, ITipoEstado
    {
        private readonly TiendaRopaDBcontext _context;

        public TipoEstadoRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}