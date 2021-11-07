using CineGba.Domain.Commands;
using CineGba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CineGba.Application.Services
{
    public interface IPeliculaService
    {
        List<Pelicula> GetAllPeliculas();
        List<Pelicula> GetAllPeliculasToday();
        Pelicula GetPeliculaById(int id);
        Pelicula GetPeliculaByTitle(string title);
        void UpdatePelicula(Pelicula pelicula);

    }
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculasRepository _repository;
        private readonly IFuncionService _funcionService;

        public PeliculaService(IPeliculasRepository repository, IFuncionService funcionService)
        {
            _repository = repository;
            _funcionService = funcionService;
        }

        public List<Pelicula> GetAllPeliculas()
        {
            return _repository.GetAllPeliculas();
        }

        public List<Pelicula> GetAllPeliculasToday()
        {
            var funciones = _funcionService.GetFuncionesByFecha(DateTime.Today.Date);
            List<Pelicula> peliculas = new List<Pelicula>();

            foreach (var funcion in funciones)
            {
                peliculas.Add(GetPeliculaById(funcion.PeliculaId));
            }

            return peliculas.Distinct().ToList();
        }

        public Pelicula GetPeliculaById(int id)
        {
            return _repository.GetPeliculaById(id);
        }

        public Pelicula GetPeliculaByTitle(string title)
        {
            return _repository.GetPeliculaByTitle(title);
        }

        public void UpdatePelicula(Pelicula pelicula)
        {
            _repository.Update(pelicula);
        }
    }
}
