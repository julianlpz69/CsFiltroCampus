using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class CargoController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public CargoController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<CargoDto>>> Get([FromQuery]Params CargoParams)
        {
        var Cargo = await unitofwork.Cargos.GetAllAsync(CargoParams.PageIndex,CargoParams.PageSize, CargoParams.Search,"descripcion");
        var listaCargos= mapper.Map<List<CargoDto>>(Cargo.registros);
        return new Pager<CargoDto>(listaCargos, Cargo.totalRegistros,CargoParams.PageIndex,CargoParams.PageSize,CargoParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<CargoDto>> Get(int id)
         {
            var Cargos = await unitofwork.Cargos.GetByIdAsync(id);
            return mapper.Map<CargoDto>(Cargos);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Cargo>> Post(CargoDto CargoDto)
          {
            var Cargo = mapper.Map<Cargo>(CargoDto);
             unitofwork.Cargos.Add(Cargo);
            await unitofwork.SaveAsync();
         
            if (Cargo == null){
                return BadRequest();
            }
            CargoDto.Id = Cargo.Id;
            return CreatedAtAction(nameof(Post), new {id = CargoDto.Id}, CargoDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<CargoDto>> Put(int id, [FromBody]CargoDto CargoDto){
            if(CargoDto == null)
                return NotFound();
          
            var Cargo = mapper.Map<Cargo>(CargoDto);
            unitofwork.Cargos.Update(Cargo);
            await unitofwork.SaveAsync();
            return CargoDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var Cargo = await unitofwork.Cargos.GetByIdAsync(id);
          if(Cargo == null)
          return NotFound();
          
          unitofwork.Cargos.Remove(Cargo);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}