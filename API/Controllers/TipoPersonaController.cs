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
    public class TipoPersonaController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public TipoPersonaController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<TipoPersonaDto>>> Get([FromQuery]Params TipoPersonaParams)
        {
        var TipoPersona = await unitofwork.TipoPersonas.GetAllAsync(TipoPersonaParams.PageIndex,TipoPersonaParams.PageSize, TipoPersonaParams.Search,"descripcion");
        var listaTipoPersonas= mapper.Map<List<TipoPersonaDto>>(TipoPersona.registros);
        return new Pager<TipoPersonaDto>(listaTipoPersonas, TipoPersona.totalRegistros,TipoPersonaParams.PageIndex,TipoPersonaParams.PageSize,TipoPersonaParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<TipoPersonaDto>> Get(int id)
         {
            var TipoPersonas = await unitofwork.TipoPersonas.GetByIdAsync(id);
            return mapper.Map<TipoPersonaDto>(TipoPersonas);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<TipoPersona>> Post(TipoPersonaDto TipoPersonaDto)
          {
            var TipoPersona = mapper.Map<TipoPersona>(TipoPersonaDto);
             unitofwork.TipoPersonas.Add(TipoPersona);
            await unitofwork.SaveAsync();
         
            if (TipoPersona == null){
                return BadRequest();
            }
            TipoPersonaDto.Id = TipoPersona.Id;
            return CreatedAtAction(nameof(Post), new {id = TipoPersonaDto.Id}, TipoPersonaDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<TipoPersonaDto>> Put(int id, [FromBody]TipoPersonaDto TipoPersonaDto){
            if(TipoPersonaDto == null)
                return NotFound();
          
            var TipoPersona = mapper.Map<TipoPersona>(TipoPersonaDto);
            unitofwork.TipoPersonas.Update(TipoPersona);
            await unitofwork.SaveAsync();
            return TipoPersonaDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var TipoPersona = await unitofwork.TipoPersonas.GetByIdAsync(id);
          if(TipoPersona == null)
          return NotFound();
          
          unitofwork.TipoPersonas.Remove(TipoPersona);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}