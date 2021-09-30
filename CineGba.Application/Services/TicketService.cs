using CineGba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGba.Application.Services
{
    public interface ITicketService
    {
        List<Ticket> GetAllTickets();
        Ticket GetTicketById(Guid id);
        List<Ticket> GetTicketsByPelicula(int peliculaId);
        List<Ticket> GetTicketsByFuncion(int funcionId);
        int GetTicketsVendidosByFuncion(int funcionId);
        int GetTicketsVendidosByPelicula(int peliculaId);
        int GetTicketsDisponiblesByFuncion(int funcionId);
    }

    public class TicketService : ITicketService
    {
        public List<Ticket> GetAllTickets()
        {
            throw new NotImplementedException();
        }

        public Ticket GetTicketById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetTicketsByFuncion(int funcionId)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetTicketsByPelicula(int peliculaId)
        {
            throw new NotImplementedException();
        }

        public int GetTicketsDisponiblesByFuncion(int funcionId)
        {
            throw new NotImplementedException();
        }

        public int GetTicketsVendidosByFuncion(int funcionId)
        {
            throw new NotImplementedException();
        }

        public int GetTicketsVendidosByPelicula(int peliculaId)
        {
            throw new NotImplementedException();
        }
    }
}
