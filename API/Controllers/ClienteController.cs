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
    public class ClienteController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public ClienteController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<ClienteDto>>> Get([FromQuery]Params ClienteParams)
        {
        var Cliente = await unitofwork.Clientes.GetAllAsync(ClienteParams.PageIndex,ClienteParams.PageSize, ClienteParams.Search,"descripcion");
        var listaClientes= mapper.Map<List<ClienteDto>>(Cliente.registros);
        return new Pager<ClienteDto>(listaClientes, Cliente.totalRegistros,ClienteParams.PageIndex,ClienteParams.PageSize,ClienteParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<ClienteDto>> Get(int id)
         {
            var Clientes = await unitofwork.Clientes.GetByIdAsync(id);
            return mapper.Map<ClienteDto>(Clientes);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Cliente>> Post(ClienteDto ClienteDto)
          {
            var Cliente = mapper.Map<Cliente>(ClienteDto);
             unitofwork.Clientes.Add(Cliente);
            await unitofwork.SaveAsync();
         
            if (Cliente == null){
                return BadRequest();
            }
            ClienteDto.Id = Cliente.Id;
            return CreatedAtAction(nameof(Post), new {id = ClienteDto.Id}, ClienteDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<ClienteDto>> Put(int id, [FromBody]ClienteDto ClienteDto){
            if(ClienteDto == null)
                return NotFound();
          
            var Cliente = mapper.Map<Cliente>(ClienteDto);
            unitofwork.Clientes.Update(Cliente);
            await unitofwork.SaveAsync();
            return ClienteDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var Cliente = await unitofwork.Clientes.GetByIdAsync(id);
          if(Cliente == null)
          return NotFound();
          
          unitofwork.Clientes.Remove(Cliente);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}