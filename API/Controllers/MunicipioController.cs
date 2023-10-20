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
    public class MunicipioController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public MunicipioController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<MunicipioDto>>> Get([FromQuery]Params MunicipioParams)
        {
        var Municipio = await unitofwork.Municipios.GetAllAsync(MunicipioParams.PageIndex,MunicipioParams.PageSize, MunicipioParams.Search,"descripcion");
        var listaMunicipios= mapper.Map<List<MunicipioDto>>(Municipio.registros);
        return new Pager<MunicipioDto>(listaMunicipios, Municipio.totalRegistros,MunicipioParams.PageIndex,MunicipioParams.PageSize,MunicipioParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<MunicipioDto>> Get(int id)
         {
            var Municipios = await unitofwork.Municipios.GetByIdAsync(id);
            return mapper.Map<MunicipioDto>(Municipios);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Municipio>> Post(MunicipioDto MunicipioDto)
          {
            var Municipio = mapper.Map<Municipio>(MunicipioDto);
             unitofwork.Municipios.Add(Municipio);
            await unitofwork.SaveAsync();
         
            if (Municipio == null){
                return BadRequest();
            }
            MunicipioDto.Id = Municipio.Id;
            return CreatedAtAction(nameof(Post), new {id = MunicipioDto.Id}, MunicipioDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<MunicipioDto>> Put(int id, [FromBody]MunicipioDto MunicipioDto){
            if(MunicipioDto == null)
                return NotFound();
          
            var Municipio = mapper.Map<Municipio>(MunicipioDto);
            unitofwork.Municipios.Update(Municipio);
            await unitofwork.SaveAsync();
            return MunicipioDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var Municipio = await unitofwork.Municipios.GetByIdAsync(id);
          if(Municipio == null)
          return NotFound();
          
          unitofwork.Municipios.Remove(Municipio);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}