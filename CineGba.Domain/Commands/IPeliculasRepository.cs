using CineGba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGba.Domain.Commands
{
    public interface IPeliculasRepository
    {
        List<Pelicula> GetAllPeliculas();
        Pelicula GetPeliculaById(int id);
        Pelicula GetPeliculaByTitle(string title);
    }
}
