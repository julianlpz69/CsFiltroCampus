using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
    {
        private readonly TiendaRopaDBcontext _context;

        public DepartamentoRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}