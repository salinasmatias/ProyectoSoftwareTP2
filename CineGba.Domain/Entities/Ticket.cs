using System;

namespace CineGba.Domain.Entities
{
    public class Ticket
    {
        public Guid TicketId { get; set; }
        public int FuncionId { get; set; }
        public string Usuario { get; set; }

        public virtual Funcion Funcion { get; set; }
    }
}
