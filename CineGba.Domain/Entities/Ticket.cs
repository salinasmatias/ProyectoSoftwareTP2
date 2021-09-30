using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
