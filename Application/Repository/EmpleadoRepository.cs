using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
    {
        private readonly TiendaRopaDBcontext _context;

        public EmpleadoRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}