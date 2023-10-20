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
    public class EmpleadoController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public EmpleadoController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<EmpleadoDto>>> Get([FromQuery]Params EmpleadoParams)
        {
        var Empleado = await unitofwork.Empleados.GetAllAsync(EmpleadoParams.PageIndex,EmpleadoParams.PageSize, EmpleadoParams.Search,"descripcion");
        var listaEmpleados= mapper.Map<List<EmpleadoDto>>(Empleado.registros);
        return new Pager<EmpleadoDto>(listaEmpleados, Empleado.totalRegistros,EmpleadoParams.PageIndex,EmpleadoParams.PageSize,EmpleadoParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<EmpleadoDto>> Get(int id)
         {
            var Empleados = await unitofwork.Empleados.GetByIdAsync(id);
            return mapper.Map<EmpleadoDto>(Empleados);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Empleado>> Post(EmpleadoDto EmpleadoDto)
          {
            var Empleado = mapper.Map<Empleado>(EmpleadoDto);
             unitofwork.Empleados.Add(Empleado);
            await unitofwork.SaveAsync();
         
            if (Empleado == null){
                return BadRequest();
            }
            EmpleadoDto.Id = Empleado.Id;
            return CreatedAtAction(nameof(Post), new {id = EmpleadoDto.Id}, EmpleadoDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<EmpleadoDto>> Put(int id, [FromBody]EmpleadoDto EmpleadoDto){
            if(EmpleadoDto == null)
                return NotFound();
          
            var Empleado = mapper.Map<Empleado>(EmpleadoDto);
            unitofwork.Empleados.Update(Empleado);
            await unitofwork.SaveAsync();
            return EmpleadoDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var Empleado = await unitofwork.Empleados.GetByIdAsync(id);
          if(Empleado == null)
          return NotFound();
          
          unitofwork.Empleados.Remove(Empleado);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}