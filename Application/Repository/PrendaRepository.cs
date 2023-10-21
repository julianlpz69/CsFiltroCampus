using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class PrendaRepository : GenericRepository<Prenda>, IPrenda
    {
        private readonly TiendaRopaDBcontext _context;

        public PrendaRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }



        public async Task<IEnumerable<Prenda>> EstadoProduccion(int Numero)
        {
            var Prendas = await _context.Prendas
                .Include(u => u.Estado.TipoEstado)
                .Where(c => c.DetalleOrdenes
                .Any(f => f.Estado.TipoEstado.Id == 2 && f.IdOrdenFK == Numero))
                .ToListAsync();
            return Prendas;
        }


        // Listar las prendas agrupadas por el tipo de protección.


        public async Task<IEnumerable<IGrouping<TipoProteccion,Prenda>>> TipoProteccion()
        {
            var Prendas = await _context.Prendas
                .Include(u => u.TipoProteccion)
                .GroupBy(u => u.TipoProteccion)
                .ToListAsync();
            return Prendas;
        }




        public async Task<IEnumerable<Prenda>> PrendasInsumos()
        {
            var Prendas = await _context.Prendas
                .Include(u => u.InsumoPrendas)
                .ToListAsync();
            return Prendas;
        }


        
    }
}