using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class InsumoRepository : GenericRepository<Insumo>, IInsumo
    {
        private readonly TiendaRopaDBcontext _context;

        public InsumoRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}