using CineGba.Domain.Commands;
using CineGba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGba.AccessData.Commands
{
    public class PeliculasRepository : IPeliculasRepository
    {
        private readonly CineContext _context;

        public PeliculasRepository(CineContext context)
        {
            _context = context;
        }
        public List<Pelicula> GetAllPeliculas()
        {
            return _context.Peliculas.ToList();
        }

        public Pelicula GetPeliculaById(int id)
        {
            return _context.Peliculas.SingleOrDefault(Pelicula => Pelicula.PeliculaId == id);
        }

        public Pelicula GetPeliculaByTitle(string title)
        {
            return _context.Peliculas.FirstOrDefault(Pelicula => Pelicula.Titulo == title);
        }

        public void Update(Pelicula pelicula)
        {
            _context.Update(pelicula);
            _context.SaveChanges();
        }
    }
}
