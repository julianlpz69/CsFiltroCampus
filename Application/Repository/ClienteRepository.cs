using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class ClienteRepository : GenericRepository<Cliente>, ICliente
    {
        private readonly TiendaRopaDBcontext _context;

        public ClienteRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}