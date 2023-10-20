using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class CargoRepository : GenericRepository<Cargo>, ICargo
    {
        private readonly TiendaRopaDBcontext _context;

        public CargoRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}