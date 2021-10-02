using CineGba.Domain.Commands;
using CineGba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CineGba.AccessData.Commands
{
    public class TicketRepository : ITicketRepository
    {
        private readonly CineContext _context;

        public TicketRepository(CineContext context)
        {
            _context = context;
        }

        public void Add(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        public void Delete(Ticket ticket)
        {
            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
        }

        public void DeleteById(Guid id)
        {
            var ticket = GetTicketById(id);
            Delete(ticket);
        }

        public List<Ticket> GetAllTickets()
        {
            return _context.Tickets.ToList();
        }

        public Ticket GetTicketById(Guid id)
        {
            return _context.Tickets.Find(id);
        }

        public List<Ticket> GetTicketsByUserAndFuncion(int funcionId, string user)
        {
            return _context.Tickets
                                    .Where(Ticket => Ticket.FuncionId == funcionId && Ticket.Usuario == user)
                                    .ToList();
        }

        public int GetTicketsDisponiblesByFuncion(int funcionId)
        {
            var funcion = _context.Funciones.Find(funcionId);
            var sala = _context.Salas.Find(funcion.SalaId);

            return sala.Capacidad - GetTicketsVendidosByFuncion(funcionId);
        }

        public int GetTicketsVendidosByFuncion(int funcionId)
        {   
            return _context.Tickets
                                    .Where(Ticket => Ticket.FuncionId == funcionId)
                                    .Count();
        }
    }
}
