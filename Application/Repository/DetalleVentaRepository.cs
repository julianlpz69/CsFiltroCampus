using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class DetalleVentaRepository : GenericRepository<DetalleVenta>, IDetalleVenta
    {
        private readonly TiendaRopaDBcontext _context;

        public DetalleVentaRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}