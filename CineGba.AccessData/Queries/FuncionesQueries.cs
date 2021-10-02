using CineGba.Domain.Commands;
using CineGba.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGba.AccessData.Queries
{
    public class FuncionesQueries : IFuncionesQueries
    {
        private readonly ITicketRepository _ticketRepository;

        public FuncionesQueries(ITicketRepository repository)
        {
            _ticketRepository = repository;
        }
        public int GetTicketsDisponiblesByFuncion(int funcionId)
        {
           return _ticketRepository.GetTicketsDisponiblesByFuncion(funcionId);
        }
    }
}
