using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
