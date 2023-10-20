using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class ColorRepository : GenericRepository<Colors>, IColor
    {
        private readonly TiendaRopaDBcontext _context;

        public ColorRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}