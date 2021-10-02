using CineGba.Application.Validations;
using CineGba.Domain.Commands;
using CineGba.Domain.Dtos;
using CineGba.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CineGba.Application.Services
{
    public interface ITicketService
    {
        List<Ticket> GetAllTickets();
        Ticket GetTicketById(Guid id);
        List<Ticket> GetTicketsByUserAndFuncion(int funcionId, string user);
        int GetTicketsVendidosByFuncion(int funcionId);
        int GetTicketsDisponiblesByFuncion(int funcionId);
        List<Ticket> CreateTicket(TicketDto ticket);
    }

    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;
        private readonly IFuncionValidation _validation;

        public TicketService(ITicketRepository repository, IFuncionValidation validation)
        {
            _repository = repository;
            _validation = validation;
        }

        public List<Ticket> CreateTicket(TicketDto ticket)
        {
            List<Ticket> ticketsVendidos = new List<Ticket>();

            if (!_validation.ValidarFuncion(ticket.FuncionId))
                return ticketsVendidos;
            
            if(ticket.Cantidad <= GetTicketsDisponiblesByFuncion(ticket.FuncionId) && ticket.Cantidad > 0)
            {
                for(int i = 0; i < ticket.Cantidad; i++)
                {
                    var ticketVendido = new Ticket
                    {
                        TicketId = Guid.NewGuid(),
                        FuncionId = ticket.FuncionId,
                        Usuario = ticket.Usuario
                    };
                    ticketsVendidos.Add(ticketVendido);
                    _repository.Add(ticketVendido);
                }
            }
            return ticketsVendidos;
        }

        public List<Ticket> GetAllTickets()
        {
           return _repository.GetAllTickets();
        }

        public Ticket GetTicketById(Guid id)
        {
            return _repository.GetTicketById(id);
        }

        public List<Ticket> GetTicketsByUserAndFuncion(int funcionId, string user)
        {
            return _repository.GetTicketsByUserAndFuncion(funcionId, user);
        }

        public int GetTicketsDisponiblesByFuncion(int funcionId)
        {
            return _repository.GetTicketsDisponiblesByFuncion(funcionId);
        }

        public int GetTicketsVendidosByFuncion(int funcionId)
        {
            return _repository.GetTicketsVendidosByFuncion(funcionId);
        }
    }
}
