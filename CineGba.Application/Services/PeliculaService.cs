using CineGba.Domain.Commands;
using CineGba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGba.Application.Services
{
    public interface IPeliculaService
    {
        List<Pelicula> GetAllPeliculas();
        Pelicula GetPeliculaById(int id);
        Pelicula GetPeliculaByTitle(string title);

    }
    public class PeliculaService : IPeliculaService
    {
        private IPeliculasRepository _repository;

        public PeliculaService(IPeliculasRepository repository)
        {
            _repository = repository;
        }

        public List<Pelicula> GetAllPeliculas()
        {
            return _repository.GetAllPeliculas();
        }

        public Pelicula GetPeliculaById(int id)
        {
            return _repository.GetPeliculaById(id);
        }

        public Pelicula GetPeliculaByTitle(string title)
        {
            return _repository.GetPeliculaByTitle(title);
        }
    }
}
