using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class GeneroRepository : GenericRepository<Genero>, IGenero
    {
        private readonly TiendaRopaDBcontext _context;

        public GeneroRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}