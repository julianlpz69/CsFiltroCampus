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
    public class DetalleVentaController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public DetalleVentaController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<DetalleVentaDto>>> Get([FromQuery]Params DetalleVentaParams)
        {
        var DetalleVenta = await unitofwork.DetalleVentas.GetAllAsync(DetalleVentaParams.PageIndex,DetalleVentaParams.PageSize, DetalleVentaParams.Search,"descripcion");
        var listaDetalleVentas= mapper.Map<List<DetalleVentaDto>>(DetalleVenta.registros);
        return new Pager<DetalleVentaDto>(listaDetalleVentas, DetalleVenta.totalRegistros,DetalleVentaParams.PageIndex,DetalleVentaParams.PageSize,DetalleVentaParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<DetalleVentaDto>> Get(int id)
         {
            var DetalleVentas = await unitofwork.DetalleVentas.GetByIdAsync(id);
            return mapper.Map<DetalleVentaDto>(DetalleVentas);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<DetalleVenta>> Post(DetalleVentaDto DetalleVentaDto)
          {
            var DetalleVenta = mapper.Map<DetalleVenta>(DetalleVentaDto);
             unitofwork.DetalleVentas.Add(DetalleVenta);
            await unitofwork.SaveAsync();
         
            if (DetalleVenta == null){
                return BadRequest();
            }
            DetalleVentaDto.Id = DetalleVenta.Id;
            return CreatedAtAction(nameof(Post), new {id = DetalleVentaDto.Id}, DetalleVentaDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<DetalleVentaDto>> Put(int id, [FromBody]DetalleVentaDto DetalleVentaDto){
            if(DetalleVentaDto == null)
                return NotFound();
          
            var DetalleVenta = mapper.Map<DetalleVenta>(DetalleVentaDto);
            unitofwork.DetalleVentas.Update(DetalleVenta);
            await unitofwork.SaveAsync();
            return DetalleVentaDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var DetalleVenta = await unitofwork.DetalleVentas.GetByIdAsync(id);
          if(DetalleVenta == null)
          return NotFound();
          
          unitofwork.DetalleVentas.Remove(DetalleVenta);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}