using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class OrdenRepository : GenericRepository<Orden>, IOrden
    {
        private readonly TiendaRopaDBcontext _context;

        public OrdenRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}