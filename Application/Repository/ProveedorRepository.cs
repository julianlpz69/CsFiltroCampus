using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
    {
        private readonly TiendaRopaDBcontext _context;

        public ProveedorRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }


        // Listar los proveedores que sean persona natural.

        public async Task<IEnumerable<Proveedor>> ProveedoresNaturales()
        {
            var proveedores = await _context.Proveedores
                .Include(p => p.TipoPersona)
                .Where(c => c.TipoPersona.NombreTipoPersona == "Persona Natural")
                .ToListAsync();
            return proveedores;
        }
    }
}