using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class PrendaProteccionDto
    {
        public int Id {get; set;}
        public string NombreProteccion {get; set;}
        public ICollection<PrendaDto> Prendas {get; set;}
    }
}