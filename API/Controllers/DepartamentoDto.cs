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
    public class DepartamentoController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public DepartamentoController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<DepartamentoDto>>> Get([FromQuery]Params DepartamentoParams)
        {
        var Departamento = await unitofwork.Departamentos.GetAllAsync(DepartamentoParams.PageIndex,DepartamentoParams.PageSize, DepartamentoParams.Search,"descripcion");
        var listaDepartamentos= mapper.Map<List<DepartamentoDto>>(Departamento.registros);
        return new Pager<DepartamentoDto>(listaDepartamentos, Departamento.totalRegistros,DepartamentoParams.PageIndex,DepartamentoParams.PageSize,DepartamentoParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<DepartamentoDto>> Get(int id)
         {
            var Departamentos = await unitofwork.Departamentos.GetByIdAsync(id);
            return mapper.Map<DepartamentoDto>(Departamentos);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Departamento>> Post(DepartamentoDto DepartamentoDto)
          {
            var Departamento = mapper.Map<Departamento>(DepartamentoDto);
             unitofwork.Departamentos.Add(Departamento);
            await unitofwork.SaveAsync();
         
            if (Departamento == null){
                return BadRequest();
            }
            DepartamentoDto.Id = Departamento.Id;
            return CreatedAtAction(nameof(Post), new {id = DepartamentoDto.Id}, DepartamentoDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<DepartamentoDto>> Put(int id, [FromBody]DepartamentoDto DepartamentoDto){
            if(DepartamentoDto == null)
                return NotFound();
          
            var Departamento = mapper.Map<Departamento>(DepartamentoDto);
            unitofwork.Departamentos.Update(Departamento);
            await unitofwork.SaveAsync();
            return DepartamentoDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var Departamento = await unitofwork.Departamentos.GetByIdAsync(id);
          if(Departamento == null)
          return NotFound();
          
          unitofwork.Departamentos.Remove(Departamento);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}