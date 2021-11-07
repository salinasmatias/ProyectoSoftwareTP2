using AutoMapper;
using CineGba.Application.Services;
using CineGba.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CineGba.Presentation.Controllers
{
    [Route("api/pelicula")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculaService _service;
        private readonly IMapper _mapper;

        public PeliculasController(IPeliculaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PeliculaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPeliculaById(int id)
        {
            try
            {
                var pelicula = _service.GetPeliculaById(id);
                var peliculaMapped = _mapper.Map<PeliculaDto>(pelicula);
                
                if (pelicula == null)
                {
                    return NotFound();
                }

                return Ok(peliculaMapped);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PeliculaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPeliculasToday()
        {
            try
            {
                var peliculas = _service.GetAllPeliculas();
                var peliculasMapped = _mapper.Map<List<PeliculaDto>>(peliculas);

                if (peliculas == null)
                {
                    return NotFound();
                }

                return Ok(peliculasMapped);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdatePelicula(int id, [FromBody]PeliculaDto pelicula)
        {
            try
            {
                if(pelicula == null)
                {
                    return BadRequest("Todos los campos deben estar completos para poder realizar la actualización de este elemento.");
                }

                var peliculaEntity = _service.GetPeliculaById(id);

                if(peliculaEntity == null)
                {
                    return NotFound();
                }

                _mapper.Map(pelicula, peliculaEntity);
                _service.UpdatePelicula(peliculaEntity);
                
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
