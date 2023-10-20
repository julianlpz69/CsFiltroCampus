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
    public class ColorController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public ColorController(IUserService userService, IUnitOfWork Unitofwork, IMapper Mapper)
        {
            _userService = userService;
            unitofwork = Unitofwork;
            mapper = Mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<ColorDto>>> Get([FromQuery]Params ColorParams)
        {
        var Color = await unitofwork.Colors.GetAllAsync(ColorParams.PageIndex,ColorParams.PageSize, ColorParams.Search,"descripcion");
        var listaColors= mapper.Map<List<ColorDto>>(Color.registros);
        return new Pager<ColorDto>(listaColors, Color.totalRegistros,ColorParams.PageIndex,ColorParams.PageSize,ColorParams.Search);
        }





        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<ColorDto>> Get(int id)
         {
            var Colors = await unitofwork.Colors.GetByIdAsync(id);
            return mapper.Map<ColorDto>(Colors);
         }



          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Colors>> Post(ColorDto ColorDto)
          {
            var Color = mapper.Map<Colors>(ColorDto);
             unitofwork.Colors.Add(Color);
            await unitofwork.SaveAsync();
         
            if (Color == null){
                return BadRequest();
            }
            ColorDto.Id = Color.Id;
            return CreatedAtAction(nameof(Post), new {id = ColorDto.Id}, ColorDto); 
          }



          [HttpPut("{id}")]
          [ProducesResponseType(StatusCodes.Status200OK)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          
          public async Task<ActionResult<ColorDto>> Put(int id, [FromBody]ColorDto ColorDto){
            if(ColorDto == null)
                return NotFound();
          
            var Color = mapper.Map<Colors>(ColorDto);
            unitofwork.Colors.Update(Color);
            await unitofwork.SaveAsync();
            return ColorDto;
          }



          [HttpDelete("{id}")]
          [ProducesResponseType(StatusCodes.Status204NoContent)]
          [ProducesResponseType(StatusCodes.Status404NotFound)]
          
          public async Task<IActionResult> Delete (int id){
          var Color = await unitofwork.Colors.GetByIdAsync(id);
          if(Color == null)
          return NotFound();
          
          unitofwork.Colors.Remove(Color);
          await unitofwork.SaveAsync();
          return NoContent();    }
    }
}