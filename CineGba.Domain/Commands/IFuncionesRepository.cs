using CineGba.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CineGba.Domain.Commands
{
    public interface IFuncionesRepository
    {
        List<Funcion> GetAllFunciones();
        Funcion GetFuncionById(int funcionId);
        List<Funcion> GetFuncionesByPelicula(int peliculaId);
        List<Funcion> GetFuncionesByPelicula(string title);
        List<Funcion> GetFuncionesByFecha(DateTime date);
        List<Funcion> GetFuncionesByFechaAndTitulo(DateTime date, string title);
        List<Funcion> GetFuncionesBySala(int salaId);
        void Add(Funcion funcion);
        void Delete(Funcion funcion);
        void DeleteById(int id);
    }
}
