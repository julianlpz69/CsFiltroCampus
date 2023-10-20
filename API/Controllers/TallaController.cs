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
    public class TallaController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public TallaController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<TallaDto>>> Get([FromQuery]Params TallaParams)
        {
        var Talla = await unitofwork.Tallas.GetAllAsync(TallaParams.PageIndex,TallaParams.PageSize, TallaParams.Search,"descripcion");
        var listaTallas= mapper.Map<List<TallaDto>>(Talla.registros);
        return new Pager<TallaDto>(listaTallas, Talla.totalRegistros,TallaParams.PageIndex,TallaParams.PageSize,TallaParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<TallaDto>> Get(int id)
         {
            var Tallas = await unitofwork.Tallas.GetByIdAsync(id);
            return mapper.Map<TallaDto>(Tallas);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Talla>> Post(TallaDto TallaDto)
          {
            var Talla = mapper.Map<Talla>(TallaDto);
             unitofwork.Tallas.Add(Talla);
            await unitofwork.SaveAsync();
         
            if (Talla == null){
                return BadRequest();
            }
            TallaDto.Id = Talla.Id;
            return CreatedAtAction(nameof(Post), new {id = TallaDto.Id}, TallaDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<TallaDto>> Put(int id, [FromBody]TallaDto TallaDto){
            if(TallaDto == null)
                return NotFound();
          
            var Talla = mapper.Map<Talla>(TallaDto);
            unitofwork.Tallas.Update(Talla);
            await unitofwork.SaveAsync();
            return TallaDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var Talla = await unitofwork.Tallas.GetByIdAsync(id);
          if(Talla == null)
          return NotFound();
          
          unitofwork.Tallas.Remove(Talla);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}