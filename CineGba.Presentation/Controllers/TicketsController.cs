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
        [ProducesResponseType(typeof(List<TicketDtoForCreation>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult CreateTicket([FromBody] TicketDto ticket)
        {
            try
            {
                var ticketEntity = _service.CreateTicket(ticket);

                if (ticketEntity.Count > 0)
                {
                    var ticketsVendidos = _mapper.Map<List<TicketDtoForCreation>>(ticketEntity);
                    return Created("~api/tickets/", ticketsVendidos);
                }

                return Conflict("Error. No hay suficientes tickets disponibles para completar esta operación.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
