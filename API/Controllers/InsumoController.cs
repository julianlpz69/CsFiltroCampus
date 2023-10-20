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
    public class InsumoController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public InsumoController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<InsumoDto>>> Get([FromQuery]Params InsumoParams)
        {
        var Insumo = await unitofwork.Insumos.GetAllAsync(InsumoParams.PageIndex,InsumoParams.PageSize, InsumoParams.Search,"descripcion");
        var listaInsumos= mapper.Map<List<InsumoDto>>(Insumo.registros);
        return new Pager<InsumoDto>(listaInsumos, Insumo.totalRegistros,InsumoParams.PageIndex,InsumoParams.PageSize,InsumoParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<InsumoDto>> Get(int id)
         {
            var Insumos = await unitofwork.Insumos.GetByIdAsync(id);
            return mapper.Map<InsumoDto>(Insumos);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Insumo>> Post(InsumoDto InsumoDto)
          {
            var Insumo = mapper.Map<Insumo>(InsumoDto);
             unitofwork.Insumos.Add(Insumo);
            await unitofwork.SaveAsync();
         
            if (Insumo == null){
                return BadRequest();
            }
            InsumoDto.Id = Insumo.Id;
            return CreatedAtAction(nameof(Post), new {id = InsumoDto.Id}, InsumoDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<InsumoDto>> Put(int id, [FromBody]InsumoDto InsumoDto){
            if(InsumoDto == null)
                return NotFound();
          
            var Insumo = mapper.Map<Insumo>(InsumoDto);
            unitofwork.Insumos.Update(Insumo);
            await unitofwork.SaveAsync();
            return InsumoDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var Insumo = await unitofwork.Insumos.GetByIdAsync(id);
          if(Insumo == null)
          return NotFound();
          
          unitofwork.Insumos.Remove(Insumo);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}