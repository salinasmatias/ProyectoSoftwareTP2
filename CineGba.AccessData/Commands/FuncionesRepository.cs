using CineGba.Domain.Commands;
using CineGba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGba.AccessData.Commands
{
    public class FuncionesRepository : IFuncionesRepository
    {
        private readonly CineContext _context;
        public FuncionesRepository(CineContext context)
        {
            _context = context;
        }

        public void Add(Funcion funcion)
        {
            _context.Funciones.Add(funcion);
            _context.SaveChanges();
        }

        public void Delete(Funcion funcion)
        {
            _context.Funciones.Remove(funcion);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var funcion = GetFuncionById(id);
            Delete(funcion);
        }

        public List<Funcion> GetAllFunciones()
        {
            return _context.Funciones
                                      .OrderByDescending(Funcion => Funcion.Fecha)
                                      .ThenByDescending(funcion => funcion.Horario)
                                      .ToList();
        }

        public Funcion GetFuncionById(int funcionId)
        {
            return _context.Funciones.Find(funcionId);
        }

        public List<Funcion> GetFuncionesByFecha(DateTime date)
        {
            return _context.Funciones
                                      .Where(Funcion => Funcion.Fecha == date)
                                      .OrderByDescending(Funcion => Funcion.Horario)
                                      .ToList();
        }

        public List<Funcion> GetFuncionesByFechaAndTitulo(DateTime date, string title)
        {
            var pelicula = _context.Peliculas.SingleOrDefault(Pelicula => Pelicula.Titulo == title);
            
            return _context.Funciones
                                     .Where(Funcion => Funcion.Fecha == date && Funcion.PeliculaId == pelicula.PeliculaId)
                                     .OrderByDescending(Funcion => Funcion.Horario)
                                     .ToList();
        }

        public List<Funcion> GetFuncionesByPelicula(int peliculaId)
        {
            return _context.Funciones
                                      .Where(Funcion => Funcion.PeliculaId == peliculaId)
                                      .OrderByDescending(Funcion => Funcion.Fecha)
                                      .ThenByDescending(Funcion => Funcion.Horario)
                                      .ToList();
        }

        public List<Funcion> GetFuncionesByPelicula(string title)
        {
            var pelicula = _context.Peliculas.SingleOrDefault(Pelicula => Pelicula.Titulo == title);
            return GetFuncionesByPelicula(pelicula.PeliculaId);
        }

        public List<Funcion> GetFuncionesBySala(int salaId)
        {
            return _context.Funciones
                                      .Where(Funcion => Funcion.SalaId == salaId)
                                      .OrderByDescending(Funcion => Funcion.Fecha)
                                      .ThenByDescending(Funcion => Funcion.Horario)
                                      .ToList();
        }
    }
}
