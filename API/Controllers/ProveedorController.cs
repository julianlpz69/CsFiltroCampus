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
    public class ProveedorController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public ProveedorController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<ProveedorDto>>> Get([FromQuery]Params ProveedorParams)
        {
        var Proveedor = await unitofwork.Proveedores.GetAllAsync(ProveedorParams.PageIndex,ProveedorParams.PageSize, ProveedorParams.Search,"NitProveedor");
        var listaProveedors= mapper.Map<List<ProveedorDto>>(Proveedor.registros);
        return new Pager<ProveedorDto>(listaProveedors, Proveedor.totalRegistros,ProveedorParams.PageIndex,ProveedorParams.PageSize,ProveedorParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<ProveedorDto>> Get(int id)
         {
            var Proveedors = await unitofwork.Proveedores.GetByIdAsync(id);
            return mapper.Map<ProveedorDto>(Proveedors);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Proveedor>> Post(ProveedorDto ProveedorDto)
          {
            var Proveedor = mapper.Map<Proveedor>(ProveedorDto);
             unitofwork.Proveedores.Add(Proveedor);
            await unitofwork.SaveAsync();
         
            if (Proveedor == null){
                return BadRequest();
            }
            ProveedorDto.Id = Proveedor.Id;
            return CreatedAtAction(nameof(Post), new {id = ProveedorDto.Id}, ProveedorDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<ProveedorDto>> Put(int id, [FromBody]ProveedorDto ProveedorDto){
            if(ProveedorDto == null)
                return NotFound();
          
            var Proveedor = mapper.Map<Proveedor>(ProveedorDto);
            unitofwork.Proveedores.Update(Proveedor);
            await unitofwork.SaveAsync();
            return ProveedorDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var Proveedor = await unitofwork.Proveedores.GetByIdAsync(id);
          if(Proveedor == null)
          return NotFound();
          
          unitofwork.Proveedores.Remove(Proveedor);
          await unitofwork.SaveAsync();
          return NoContent();    }

            
           [HttpGet("Naturales")]
           [ProducesResponseType(StatusCodes.Status200OK)]
           [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
           public async Task<ActionResult<IEnumerable<ProveedorNaturaDto>>> Get()
           {
            var Proveedores = await unitofwork.Proveedores.ProveedoresNaturales();
            return mapper.Map<List<ProveedorNaturaDto>>(Proveedores);
           }
    }
}