using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class TipoPersonaRepository : GenericRepository<TipoPersona>, ITipoPersona
    {
        private readonly TiendaRopaDBcontext _context;

        public TipoPersonaRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}