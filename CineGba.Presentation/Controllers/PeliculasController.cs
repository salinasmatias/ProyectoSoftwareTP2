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

        [HttpGet]
        public IActionResult GetAllPeliculas()
        {
            try
            {
                var peliculas = _service.GetAllPeliculas();
                var peliculasResult = _mapper.Map<List<PeliculaDto>>(peliculas);

                return Ok(peliculasResult);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PeliculaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
    }
}
