using API.Dtos;
using API.Helpers;
using API.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class VentaController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public VentaController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<VentaDto>>> Get([FromQuery]Params VentaParams)
        {
        var Venta = await unitofwork.Ventas.GetAllAsync(VentaParams.PageIndex,VentaParams.PageSize, VentaParams.Search,"descripcion");
        var listaVentas= mapper.Map<List<VentaDto>>(Venta.registros);
        return new Pager<VentaDto>(listaVentas, Venta.totalRegistros,VentaParams.PageIndex,VentaParams.PageSize,VentaParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<VentaDto>> Get(int id)
         {
            var Ventas = await unitofwork.Ventas.GetByIdAsync(id);
            return mapper.Map<VentaDto>(Ventas);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Venta>> Post(VentaDto VentaDto)
          {
            var Venta = mapper.Map<Venta>(VentaDto);
             unitofwork.Ventas.Add(Venta);
            await unitofwork.SaveAsync();
         
            if (Venta == null){
                return BadRequest();
            }
            VentaDto.Id = Venta.Id;
            return CreatedAtAction(nameof(Post), new {id = VentaDto.Id}, VentaDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<VentaDto>> Put(int id, [FromBody]VentaDto VentaDto){
            if(VentaDto == null)
                return NotFound();
          
            var Venta = mapper.Map<Venta>(VentaDto);
            unitofwork.Ventas.Update(Venta);
            await unitofwork.SaveAsync();
            return VentaDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var Venta = await unitofwork.Ventas.GetByIdAsync(id);
          if(Venta == null)
          return NotFound();
          
          unitofwork.Ventas.Remove(Venta);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}