using AutoMapper;
using CineGba.Application.Services;
using CineGba.Domain.Dtos;
using CineGba.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineGba.Presentation.Controllers
{
    [Route("api/funcion")]
    [ApiController]
    public class FuncionesController : ControllerBase
    {
        private readonly IFuncionService _service;
        private readonly IMapper _mapper;

        public FuncionesController(IFuncionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(FuncionDto), StatusCodes.Status200OK)]
        public IActionResult GetFuncionesByTitleOrFecha(DateTime? fecha = null, string titulo = null )
        {
            try
            {
                if (fecha == null)
                    fecha = DateTime.Now.Date;


                if (titulo == null)
                {
                    var funciones = _service.GetFuncionesByFecha(fecha.Value.Date);
                    var funcionesMapeadas = _mapper.Map<List<FuncionDto>>(funciones);

                    return Ok(funcionesMapeadas);
                }
                else
                {
                    var funciones = _service.GetFuncionesByFechaAndTitulo(fecha.Value.Date, titulo);
                    var funcionesMapeadas = _mapper.Map<List<FuncionDto>>(funciones);

                    return Ok(funcionesMapeadas);
                }

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(FuncionDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateFuncion([FromBody]FuncionDto funcion)
        {
            try
            {
                var funcionEntity = _service.CreateFuncion(funcion);

                if (funcionEntity != null)
                {
                    var funcionCreada = _mapper.Map<FuncionDto>(funcionEntity);
                    return Created("~api/funcion/", funcionCreada);
                }
                
                return BadRequest("Error, el horario y fecha de la función a crear se superpone con una función ya existente en el sistema.");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteFuncion(int id)
        {
            try
            {
                var funcion = _service.GetFuncionById(id);
                if(funcion == null)
                {
                    return NotFound();
                }
                
                _service.DeleteFuncion(funcion);
                return NoContent();

            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }
    }
}
