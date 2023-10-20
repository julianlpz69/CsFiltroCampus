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
    public class TipoEstadoController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public TipoEstadoController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<TipoEstadoDto>>> Get([FromQuery]Params TipoEstadoParams)
        {
        var TipoEstado = await unitofwork.TipoEstados.GetAllAsync(TipoEstadoParams.PageIndex,TipoEstadoParams.PageSize, TipoEstadoParams.Search,"descripcion");
        var listaTipoEstados= mapper.Map<List<TipoEstadoDto>>(TipoEstado.registros);
        return new Pager<TipoEstadoDto>(listaTipoEstados, TipoEstado.totalRegistros,TipoEstadoParams.PageIndex,TipoEstadoParams.PageSize,TipoEstadoParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<TipoEstadoDto>> Get(int id)
         {
            var TipoEstados = await unitofwork.TipoEstados.GetByIdAsync(id);
            return mapper.Map<TipoEstadoDto>(TipoEstados);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<TipoEstado>> Post(TipoEstadoDto TipoEstadoDto)
          {
            var TipoEstado = mapper.Map<TipoEstado>(TipoEstadoDto);
             unitofwork.TipoEstados.Add(TipoEstado);
            await unitofwork.SaveAsync();
         
            if (TipoEstado == null){
                return BadRequest();
            }
            TipoEstadoDto.Id = TipoEstado.Id;
            return CreatedAtAction(nameof(Post), new {id = TipoEstadoDto.Id}, TipoEstadoDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<TipoEstadoDto>> Put(int id, [FromBody]TipoEstadoDto TipoEstadoDto){
            if(TipoEstadoDto == null)
                return NotFound();
          
            var TipoEstado = mapper.Map<TipoEstado>(TipoEstadoDto);
            unitofwork.TipoEstados.Update(TipoEstado);
            await unitofwork.SaveAsync();
            return TipoEstadoDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var TipoEstado = await unitofwork.TipoEstados.GetByIdAsync(id);
          if(TipoEstado == null)
          return NotFound();
          
          unitofwork.TipoEstados.Remove(TipoEstado);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}