using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Orden>> OrdenesServicio(int Numero)
        {
            var Ordenes = await _context.Ordenes
                .Include(u => u.Cliente)
                .Include(u => u.DetalleOrdenes)
                .Include(u => u.DetalleOrdenes)
                .Where(c => c.IdClienteFK == Numero)
                .ToListAsync();
            return Ordenes;
        }

    }
}