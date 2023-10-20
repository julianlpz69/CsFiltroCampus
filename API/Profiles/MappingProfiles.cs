using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

        //     CreateMap<IGrouping<Especie, Mascota>, DtoEspecieMacota>()
        //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Key.Id))
        //    .ForMember(dest => dest.NombreEspecie, opt => opt.MapFrom(src => src.Key.NombreEspecie))
        //    .ForMember(dest => dest.Mascotas, opt => opt.MapFrom(src => src));

        //    CreateMap<Mascota, MascotaPetDto>();

        }
    }
}