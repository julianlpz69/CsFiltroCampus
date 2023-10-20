using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class MunicipioRepository : GenericRepository<Municipio>, IMunicipio
    {
        private readonly TiendaRopaDBcontext _context;

        public MunicipioRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}