using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class EmpresaRepository : GenericRepository<Empresa>, IEmpresa
    {
        private readonly TiendaRopaDBcontext _context;

        public EmpresaRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}