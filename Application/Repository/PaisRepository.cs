using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class PaisRepository : GenericRepository<Pais>, IPais
    {
        private readonly TiendaRopaDBcontext _context;

        public PaisRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}