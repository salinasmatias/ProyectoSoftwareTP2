using AutoMapper;
using CineGba.Application.Services;
using CineGba.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CineGba.Presentation.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _service;
        private readonly IMapper _mapper;

        public TicketsController(ITicketService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<TicketDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult CreateTicket([FromBody] TicketDto tickets)
        {
            try
            {
                var ticketEntity = _service.CreateTicket(tickets);

                if (ticketEntity.Count > 0)
                    return Created("~api/tickets/", tickets);
                

                return Conflict("Ocurrió un problema. El número de función ingresado no corresponde a una función " +
                                "registrada en el sistema, o La cantidad de tickets en la petición es 0, o supera a la cantidad" +
                                "de tickets disponibles para esta función. \n\n" +
                                "Revise la petición e inténtelo nuevamente.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
