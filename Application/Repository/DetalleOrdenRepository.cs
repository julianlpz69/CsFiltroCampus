using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class DetalleOrdenRepository : GenericRepository<DetalleOrden>, IDetalleOrden
    {
        private readonly TiendaRopaDBcontext _context;

        public DetalleOrdenRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}