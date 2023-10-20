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
    public class GeneroController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public GeneroController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<GeneroDto>>> Get([FromQuery]Params GeneroParams)
        {
        var Genero = await unitofwork.Generos.GetAllAsync(GeneroParams.PageIndex,GeneroParams.PageSize, GeneroParams.Search,"descripcion");
        var listaGeneros= mapper.Map<List<GeneroDto>>(Genero.registros);
        return new Pager<GeneroDto>(listaGeneros, Genero.totalRegistros,GeneroParams.PageIndex,GeneroParams.PageSize,GeneroParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<GeneroDto>> Get(int id)
         {
            var Generos = await unitofwork.Generos.GetByIdAsync(id);
            return mapper.Map<GeneroDto>(Generos);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Genero>> Post(GeneroDto GeneroDto)
          {
            var Genero = mapper.Map<Genero>(GeneroDto);
             unitofwork.Generos.Add(Genero);
            await unitofwork.SaveAsync();
         
            if (Genero == null){
                return BadRequest();
            }
            GeneroDto.Id = Genero.Id;
            return CreatedAtAction(nameof(Post), new {id = GeneroDto.Id}, GeneroDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<GeneroDto>> Put(int id, [FromBody]GeneroDto GeneroDto){
            if(GeneroDto == null)
                return NotFound();
          
            var Genero = mapper.Map<Genero>(GeneroDto);
            unitofwork.Generos.Update(Genero);
            await unitofwork.SaveAsync();
            return GeneroDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var Genero = await unitofwork.Generos.GetByIdAsync(id);
          if(Genero == null)
          return NotFound();
          
          unitofwork.Generos.Remove(Genero);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}