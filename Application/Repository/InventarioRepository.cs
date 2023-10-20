using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class InventarioRepository : GenericRepository<Inventario>, IInventario
    {
        private readonly TiendaRopaDBcontext _context;

        public InventarioRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}