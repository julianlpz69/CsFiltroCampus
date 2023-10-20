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
    public class FormaPagoController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public FormaPagoController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<FormaPagoDto>>> Get([FromQuery]Params FormaPagoParams)
        {
        var FormaPago = await unitofwork.FormaPagos.GetAllAsync(FormaPagoParams.PageIndex,FormaPagoParams.PageSize, FormaPagoParams.Search,"descripcion");
        var listaFormaPagos= mapper.Map<List<FormaPagoDto>>(FormaPago.registros);
        return new Pager<FormaPagoDto>(listaFormaPagos, FormaPago.totalRegistros,FormaPagoParams.PageIndex,FormaPagoParams.PageSize,FormaPagoParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<FormaPagoDto>> Get(int id)
         {
            var FormaPagos = await unitofwork.FormaPagos.GetByIdAsync(id);
            return mapper.Map<FormaPagoDto>(FormaPagos);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<FormaPago>> Post(FormaPagoDto FormaPagoDto)
          {
            var FormaPago = mapper.Map<FormaPago>(FormaPagoDto);
             unitofwork.FormaPagos.Add(FormaPago);
            await unitofwork.SaveAsync();
         
            if (FormaPago == null){
                return BadRequest();
            }
            FormaPagoDto.Id = FormaPago.Id;
            return CreatedAtAction(nameof(Post), new {id = FormaPagoDto.Id}, FormaPagoDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<FormaPagoDto>> Put(int id, [FromBody]FormaPagoDto FormaPagoDto){
            if(FormaPagoDto == null)
                return NotFound();
          
            var FormaPago = mapper.Map<FormaPago>(FormaPagoDto);
            unitofwork.FormaPagos.Update(FormaPago);
            await unitofwork.SaveAsync();
            return FormaPagoDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var FormaPago = await unitofwork.FormaPagos.GetByIdAsync(id);
          if(FormaPago == null)
          return NotFound();
          
          unitofwork.FormaPagos.Remove(FormaPago);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}