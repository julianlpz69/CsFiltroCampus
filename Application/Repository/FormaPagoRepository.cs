using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class FormaPagoRepository : GenericRepository<FormaPago>, IFormaPago
    {
        private readonly TiendaRopaDBcontext _context;

        public FormaPagoRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}