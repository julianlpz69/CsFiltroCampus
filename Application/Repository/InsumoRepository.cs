using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Insumo>> InsumosProveedor(string Numero)
        {
            var Insumos = await _context.Insumos
                .Where(c => c.InsumoProveedores
                .Any(f => f.Proveedor.NitProveedor == Numero))
                .ToListAsync();
            return Insumos;
        }
    }
}