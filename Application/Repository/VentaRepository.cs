using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class VentaRepository : GenericRepository<Venta>, IVenta
    {
        private readonly TiendaRopaDBcontext _context;

        public VentaRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Venta>> EmpleadosVentas(int Numero)
        {
            var Ventas = await _context.Ventas
                .Include(u => u.Empleado)
                .Include(u => u.DetalleVentas)
                .Where(c => c.IdEmpleadoFK == Numero)
                .ToListAsync();
            return Ventas;
        }

    }
}