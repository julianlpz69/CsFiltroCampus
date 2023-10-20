using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class EstadoRepository : GenericRepository<Estado>, IEstado
    {
        private readonly TiendaRopaDBcontext _context;

        public EstadoRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}