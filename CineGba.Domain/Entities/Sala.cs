using System.Collections.Generic;

namespace CineGba.Domain.Entities
{
    public class Sala
    {
        public Sala()
        {
            Funciones = new HashSet<Funcion>();
        }

        public int SalaId { get; set; }
        public int Capacidad { get; set; }

        public virtual ICollection<Funcion> Funciones { get; set; }
    }
}
