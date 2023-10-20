using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class RolRepository : GenericRepository<Rol>, IRol
    {
        private readonly TiendaRopaDBcontext _context;

        public RolRepository(TiendaRopaDBcontext context):base(context)
        {
            _context = context;
        }
    }
}