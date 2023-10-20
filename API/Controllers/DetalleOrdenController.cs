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
    public class DetalleOrdenController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public DetalleOrdenController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<DetalleOrdenDto>>> Get([FromQuery]Params DetalleOrdenParams)
        {
        var DetalleOrden = await unitofwork.DetalleOrdenes.GetAllAsync(DetalleOrdenParams.PageIndex,DetalleOrdenParams.PageSize, DetalleOrdenParams.Search,"descripcion");
        var listaDetalleOrdens= mapper.Map<List<DetalleOrdenDto>>(DetalleOrden.registros);
        return new Pager<DetalleOrdenDto>(listaDetalleOrdens, DetalleOrden.totalRegistros,DetalleOrdenParams.PageIndex,DetalleOrdenParams.PageSize,DetalleOrdenParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<DetalleOrdenDto>> Get(int id)
         {
            var DetalleOrdens = await unitofwork.DetalleOrdenes.GetByIdAsync(id);
            return mapper.Map<DetalleOrdenDto>(DetalleOrdens);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<DetalleOrden>> Post(DetalleOrdenDto DetalleOrdenDto)
          {
            var DetalleOrden = mapper.Map<DetalleOrden>(DetalleOrdenDto);
             unitofwork.DetalleOrdenes.Add(DetalleOrden);
            await unitofwork.SaveAsync();
         
            if (DetalleOrden == null){
                return BadRequest();
            }
            DetalleOrdenDto.Id = DetalleOrden.Id;
            return CreatedAtAction(nameof(Post), new {id = DetalleOrdenDto.Id}, DetalleOrdenDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<DetalleOrdenDto>> Put(int id, [FromBody]DetalleOrdenDto DetalleOrdenDto){
            if(DetalleOrdenDto == null)
                return NotFound();
          
            var DetalleOrden = mapper.Map<DetalleOrden>(DetalleOrdenDto);
            unitofwork.DetalleOrdenes.Update(DetalleOrden);
            await unitofwork.SaveAsync();
            return DetalleOrdenDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var DetalleOrden = await unitofwork.DetalleOrdenes.GetByIdAsync(id);
          if(DetalleOrden == null)
          return NotFound();
          
          unitofwork.DetalleOrdenes.Remove(DetalleOrden);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}