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
    public class PaisController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public PaisController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<PaisDto>>> Get([FromQuery]Params PaisParams)
        {
        var Pais = await unitofwork.Paises.GetAllAsync(PaisParams.PageIndex,PaisParams.PageSize, PaisParams.Search,"descripcion");
        var listaPaiss= mapper.Map<List<PaisDto>>(Pais.registros);
        return new Pager<PaisDto>(listaPaiss, Pais.totalRegistros,PaisParams.PageIndex,PaisParams.PageSize,PaisParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<PaisDto>> Get(int id)
         {
            var Paiss = await unitofwork.Paises.GetByIdAsync(id);
            return mapper.Map<PaisDto>(Paiss);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Pais>> Post(PaisDto PaisDto)
          {
            var Pais = mapper.Map<Pais>(PaisDto);
             unitofwork.Paises.Add(Pais);
            await unitofwork.SaveAsync();
         
            if (Pais == null){
                return BadRequest();
            }
            PaisDto.Id = Pais.Id;
            return CreatedAtAction(nameof(Post), new {id = PaisDto.Id}, PaisDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<PaisDto>> Put(int id, [FromBody]PaisDto PaisDto){
            if(PaisDto == null)
                return NotFound();
          
            var Pais = mapper.Map<Pais>(PaisDto);
            unitofwork.Paises.Update(Pais);
            await unitofwork.SaveAsync();
            return PaisDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var Pais = await unitofwork.Paises.GetByIdAsync(id);
          if(Pais == null)
          return NotFound();
          
          unitofwork.Paises.Remove(Pais);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}