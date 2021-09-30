using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGba.Domain.Entities
{
    public class Pelicula
    {
        public Pelicula()
        {
            Funciones = new HashSet<Funcion>();
        }

        public int PeliculaId { get; set; }
        public string Titulo { get; set; }
        public string Poster { get; set; }
        public string Sinopsis { get; set; }
        public string Trailer { get; set; }

        public virtual ICollection<Funcion> Funciones { get; set; }
    }
}
