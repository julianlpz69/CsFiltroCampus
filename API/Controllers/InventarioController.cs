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
    public class InventarioController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public InventarioController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<InventarioDto>>> Get([FromQuery]Params InventarioParams)
        {
        var Inventario = await unitofwork.Inventarios.GetAllAsync(InventarioParams.PageIndex,InventarioParams.PageSize, InventarioParams.Search,"descripcion");
        var listaInventarios= mapper.Map<List<InventarioDto>>(Inventario.registros);
        return new Pager<InventarioDto>(listaInventarios, Inventario.totalRegistros,InventarioParams.PageIndex,InventarioParams.PageSize,InventarioParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<InventarioDto>> Get(int id)
         {
            var Inventarios = await unitofwork.Inventarios.GetByIdAsync(id);
            return mapper.Map<InventarioDto>(Inventarios);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Inventario>> Post(InventarioDto InventarioDto)
          {
            var Inventario = mapper.Map<Inventario>(InventarioDto);
             unitofwork.Inventarios.Add(Inventario);
            await unitofwork.SaveAsync();
         
            if (Inventario == null){
                return BadRequest();
            }
            InventarioDto.Id = Inventario.Id;
            return CreatedAtAction(nameof(Post), new {id = InventarioDto.Id}, InventarioDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<InventarioDto>> Put(int id, [FromBody]InventarioDto InventarioDto){
            if(InventarioDto == null)
                return NotFound();
          
            var Inventario = mapper.Map<Inventario>(InventarioDto);
            unitofwork.Inventarios.Update(Inventario);
            await unitofwork.SaveAsync();
            return InventarioDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var Inventario = await unitofwork.Inventarios.GetByIdAsync(id);
          if(Inventario == null)
          return NotFound();
          
          unitofwork.Inventarios.Remove(Inventario);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}