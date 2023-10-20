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
    public class EmpresaController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public EmpresaController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<EmpresaDto>>> Get([FromQuery]Params EmpresaParams)
        {
        var Empresa = await unitofwork.Empresas.GetAllAsync(EmpresaParams.PageIndex,EmpresaParams.PageSize, EmpresaParams.Search,"descripcion");
        var listaEmpresas= mapper.Map<List<EmpresaDto>>(Empresa.registros);
        return new Pager<EmpresaDto>(listaEmpresas, Empresa.totalRegistros,EmpresaParams.PageIndex,EmpresaParams.PageSize,EmpresaParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<EmpresaDto>> Get(int id)
         {
            var Empresas = await unitofwork.Empresas.GetByIdAsync(id);
            return mapper.Map<EmpresaDto>(Empresas);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Empresa>> Post(EmpresaDto EmpresaDto)
          {
            var Empresa = mapper.Map<Empresa>(EmpresaDto);
             unitofwork.Empresas.Add(Empresa);
            await unitofwork.SaveAsync();
         
            if (Empresa == null){
                return BadRequest();
            }
            EmpresaDto.Id = Empresa.Id;
            return CreatedAtAction(nameof(Post), new {id = EmpresaDto.Id}, EmpresaDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<EmpresaDto>> Put(int id, [FromBody]EmpresaDto EmpresaDto){
            if(EmpresaDto == null)
                return NotFound();
          
            var Empresa = mapper.Map<Empresa>(EmpresaDto);
            unitofwork.Empresas.Update(Empresa);
            await unitofwork.SaveAsync();
            return EmpresaDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var Empresa = await unitofwork.Empresas.GetByIdAsync(id);
          if(Empresa == null)
          return NotFound();
          
          unitofwork.Empresas.Remove(Empresa);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}