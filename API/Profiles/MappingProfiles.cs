using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<IGrouping<TipoProteccion, Prenda>, PrendaProteccionDto>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Key.Id))
           .ForMember(dest => dest.NombreProteccion, opt => opt.MapFrom(src => src.Key.Descripcion))
           .ForMember(dest => dest.Prendas, opt => opt.MapFrom(src => src));

           CreateMap<Cargo, CargoDto>().ReverseMap();

           CreateMap<Cliente, ClienteDto>().ReverseMap();

           CreateMap<Colors, ColorDto>().ReverseMap();

           CreateMap<Departamento, DepartamentoDto>().ReverseMap();

           CreateMap<DetalleOrden, DetalleOrdenDto>().ReverseMap();

           CreateMap<DetalleVenta, DetalleVentaDto>().ReverseMap();

           CreateMap<Empleado, EmpleadoDto>().ReverseMap();

           CreateMap<Empresa, EmpresaDto>().ReverseMap();

           CreateMap<Estado, EstadoDto>().ReverseMap();
           
           CreateMap<Prenda, PrendaInsumosDto>()
           .ForMember(dest => dest.ValorRealizarPrenda, opt => opt.MapFrom(src => src.ValorUnitCop));



           CreateMap<Insumo, InsumoPrendaDto>().ReverseMap();
           CreateMap<Estado, EstadoDto>().ReverseMap();

           CreateMap<FormaPago, FormaPagoDto>().ReverseMap();

           CreateMap<Genero, GeneroDto>().ReverseMap();

           CreateMap<Insumo, InsumoDto>().ReverseMap();

           CreateMap<Inventario, InventarioDto>().ReverseMap();

           CreateMap<Municipio, MunicipioDto>().ReverseMap();

           CreateMap<Orden, OrdenDto>().ReverseMap();
           CreateMap<Orden, OrdenSeviciolDto>().ReverseMap();

           CreateMap<Pais, PaisDto>().ReverseMap();

           CreateMap<Prenda, PrendaDto>().ReverseMap();
           CreateMap<Prenda, PrendaProduccionDto>()
           .ForMember(dest => dest.IdPrenda, opt => opt.MapFrom(src => src.IdPrenda))
           .ForMember(dest => dest.EstadoProduccion, opt => opt.MapFrom(src => "En Produccion"));

            CreateMap<Proveedor, ProveedorDto>().ReverseMap();

            CreateMap<Proveedor, ProveedorNaturaDto>()
            .ForMember(dest => dest.NombreTipoPersona, opt => opt.MapFrom(src => src.TipoPersona.NombreTipoPersona));

           CreateMap<Talla, TallaDto>().ReverseMap();

           CreateMap<TipoEstado, TipoEstadoDto>().ReverseMap();

           CreateMap<TipoPersona, TipoPersonaDto>().ReverseMap();

           CreateMap<TipoProteccion, TipoProteccionDto>().ReverseMap();

           CreateMap<Venta, VentaDto>().ReverseMap();
           CreateMap<Venta, VentaEmpleadoDto>().ReverseMap();

        }
    }
}