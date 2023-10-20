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
    public class PrendaController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public PrendaController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<PrendaDto>>> Get([FromQuery]Params PrendaParams)
        {
        var Prenda = await unitofwork.Prendas.GetAllAsync(PrendaParams.PageIndex,PrendaParams.PageSize, PrendaParams.Search,"descripcion");
        var listaPrendas= mapper.Map<List<PrendaDto>>(Prenda.registros);
        return new Pager<PrendaDto>(listaPrendas, Prenda.totalRegistros,PrendaParams.PageIndex,PrendaParams.PageSize,PrendaParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<PrendaDto>> Get(int id)
         {
            var Prendas = await unitofwork.Prendas.GetByIdAsync(id);
            return mapper.Map<PrendaDto>(Prendas);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Prenda>> Post(PrendaDto PrendaDto)
          {
            var Prenda = mapper.Map<Prenda>(PrendaDto);
             unitofwork.Prendas.Add(Prenda);
            await unitofwork.SaveAsync();
         
            if (Prenda == null){
                return BadRequest();
            }
            PrendaDto.Id = Prenda.Id;
            return CreatedAtAction(nameof(Post), new {id = PrendaDto.Id}, PrendaDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<PrendaDto>> Put(int id, [FromBody]PrendaDto PrendaDto){
            if(PrendaDto == null)
                return NotFound();
          
            var Prenda = mapper.Map<Prenda>(PrendaDto);
            unitofwork.Prendas.Update(Prenda);
            await unitofwork.SaveAsync();
            return PrendaDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var Prenda = await unitofwork.Prendas.GetByIdAsync(id);
          if(Prenda == null)
          return NotFound();
          
          unitofwork.Prendas.Remove(Prenda);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}