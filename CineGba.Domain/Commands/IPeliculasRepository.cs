using CineGba.Domain.Entities;
using System.Collections.Generic;

namespace CineGba.Domain.Commands
{
    public interface IPeliculasRepository
    {
        List<Pelicula> GetAllPeliculas();
        Pelicula GetPeliculaById(int id);
        Pelicula GetPeliculaByTitle(string title);
        void Update(Pelicula pelicula);
    }
}
