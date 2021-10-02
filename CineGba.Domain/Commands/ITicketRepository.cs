using CineGba.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CineGba.Domain.Commands
{
    public interface ITicketRepository
    {
        List<Ticket> GetAllTickets();
        Ticket GetTicketById(Guid id);
        List<Ticket> GetTicketsByUserAndFuncion(int funcionId, string user);
        int GetTicketsVendidosByFuncion(int funcionId);
        int GetTicketsDisponiblesByFuncion(int funcionId);
        void Add(Ticket ticket);
        void Delete(Ticket ticket);
        void DeleteById(Guid id);
    }
}
