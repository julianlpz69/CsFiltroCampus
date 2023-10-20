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
    public class TipoProteccionController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public TipoProteccionController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<TipoProteccionDto>>> Get([FromQuery]Params TipoProteccionParams)
        {
        var TipoProteccion = await unitofwork.TipoProtecciones.GetAllAsync(TipoProteccionParams.PageIndex,TipoProteccionParams.PageSize, TipoProteccionParams.Search,"descripcion");
        var listaTipoProteccions= mapper.Map<List<TipoProteccionDto>>(TipoProteccion.registros);
        return new Pager<TipoProteccionDto>(listaTipoProteccions, TipoProteccion.totalRegistros,TipoProteccionParams.PageIndex,TipoProteccionParams.PageSize,TipoProteccionParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<TipoProteccionDto>> Get(int id)
         {
            var TipoProteccions = await unitofwork.TipoProtecciones.GetByIdAsync(id);
            return mapper.Map<TipoProteccionDto>(TipoProteccions);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<TipoProteccion>> Post(TipoProteccionDto TipoProteccionDto)
          {
            var TipoProteccion = mapper.Map<TipoProteccion>(TipoProteccionDto);
             unitofwork.TipoProtecciones.Add(TipoProteccion);
            await unitofwork.SaveAsync();
         
            if (TipoProteccion == null){
                return BadRequest();
            }
            TipoProteccionDto.Id = TipoProteccion.Id;
            return CreatedAtAction(nameof(Post), new {id = TipoProteccionDto.Id}, TipoProteccionDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<TipoProteccionDto>> Put(int id, [FromBody]TipoProteccionDto TipoProteccionDto){
            if(TipoProteccionDto == null)
                return NotFound();
          
            var TipoProteccion = mapper.Map<TipoProteccion>(TipoProteccionDto);
            unitofwork.TipoProtecciones.Update(TipoProteccion);
            await unitofwork.SaveAsync();
            return TipoProteccionDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var TipoProteccion = await unitofwork.TipoProtecciones.GetByIdAsync(id);
          if(TipoProteccion == null)
          return NotFound();
          
          unitofwork.TipoProtecciones.Remove(TipoProteccion);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}