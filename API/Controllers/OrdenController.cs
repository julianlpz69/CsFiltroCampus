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
    public class OrdenController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public OrdenController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<OrdenDto>>> Get([FromQuery]Params OrdenParams)
        {
        var Orden = await unitofwork.Ordenes.GetAllAsync(OrdenParams.PageIndex,OrdenParams.PageSize, OrdenParams.Search,"descripcion");
        var listaOrdens= mapper.Map<List<OrdenDto>>(Orden.registros);
        return new Pager<OrdenDto>(listaOrdens, Orden.totalRegistros,OrdenParams.PageIndex,OrdenParams.PageSize,OrdenParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<OrdenDto>> Get(int id)
         {
            var Ordens = await unitofwork.Ordenes.GetByIdAsync(id);
            return mapper.Map<OrdenDto>(Ordens);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Orden>> Post(OrdenDto OrdenDto)
          {
            var Orden = mapper.Map<Orden>(OrdenDto);
             unitofwork.Ordenes.Add(Orden);
            await unitofwork.SaveAsync();
         
            if (Orden == null){
                return BadRequest();
            }
            OrdenDto.Id = Orden.Id;
            return CreatedAtAction(nameof(Post), new {id = OrdenDto.Id}, OrdenDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<OrdenDto>> Put(int id, [FromBody]OrdenDto OrdenDto){
            if(OrdenDto == null)
                return NotFound();
          
            var Orden = mapper.Map<Orden>(OrdenDto);
            unitofwork.Ordenes.Update(Orden);
            await unitofwork.SaveAsync();
            return OrdenDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var Orden = await unitofwork.Ordenes.GetByIdAsync(id);
          if(Orden == null)
          return NotFound();
          
          unitofwork.Ordenes.Remove(Orden);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}