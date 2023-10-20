using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class TallaRepository : GenericRepository<Talla>, ITalla
    {
        private readonly TiendaRopaDBcontext _context;

        public TallaRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}