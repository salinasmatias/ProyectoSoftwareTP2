using System;
using System.Collections.Generic;

namespace CineGba.Domain.Entities
{
    public class Funcion
    {
        public Funcion()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int FuncionId { get; set; }
        public int PeliculaId { get; set; }
        public int SalaId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan? Horario { get; set; }

        public virtual Pelicula Pelicula { get; set; }
        public virtual Sala Sala { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
