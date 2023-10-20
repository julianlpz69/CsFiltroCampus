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
    public class EstadoController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public EstadoController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<EstadoDto>>> Get([FromQuery]Params EstadoParams)
        {
        var Estado = await unitofwork.Estados.GetAllAsync(EstadoParams.PageIndex,EstadoParams.PageSize, EstadoParams.Search,"descripcion");
        var listaEstados= mapper.Map<List<EstadoDto>>(Estado.registros);
        return new Pager<EstadoDto>(listaEstados, Estado.totalRegistros,EstadoParams.PageIndex,EstadoParams.PageSize,EstadoParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<EstadoDto>> Get(int id)
         {
            var Estados = await unitofwork.Estados.GetByIdAsync(id);
            return mapper.Map<EstadoDto>(Estados);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Estado>> Post(EstadoDto EstadoDto)
          {
            var Estado = mapper.Map<Estado>(EstadoDto);
             unitofwork.Estados.Add(Estado);
            await unitofwork.SaveAsync();
         
            if (Estado == null){
                return BadRequest();
            }
            EstadoDto.Id = Estado.Id;
            return CreatedAtAction(nameof(Post), new {id = EstadoDto.Id}, EstadoDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<EstadoDto>> Put(int id, [FromBody]EstadoDto EstadoDto){
            if(EstadoDto == null)
                return NotFound();
          
            var Estado = mapper.Map<Estado>(EstadoDto);
            unitofwork.Estados.Update(Estado);
            await unitofwork.SaveAsync();
            return EstadoDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var Estado = await unitofwork.Estados.GetByIdAsync(id);
          if(Estado == null)
          return NotFound();
          
          unitofwork.Estados.Remove(Estado);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}