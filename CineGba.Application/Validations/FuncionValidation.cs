using CineGba.Domain.Commands;
using CineGba.Domain.Entities;
using System;
using System.Linq;

namespace CineGba.Application.Validations
{
    public interface IFuncionValidation
    {
        bool ValidarFuncion(Funcion funcion);
    }
    public class FuncionValidation : IFuncionValidation
    {
        private readonly IFuncionesRepository _repository;

        public FuncionValidation(IFuncionesRepository repository)
        {
            _repository = repository;
        }
        
        public bool ValidarFuncion(Funcion funcion)
        {
            var funciones = _repository.GetAllFunciones().Where(F => F.SalaId == funcion.SalaId && F.Fecha.Date == funcion.Fecha.Date).ToList();
            var duracionFuncion = new TimeSpan(2, 30, 0);

            foreach (var F in funciones)
            {
                if ((funcion.Horario.Value - F.Horario.Value).Duration() < duracionFuncion)
                    return false;
            }
            return true;
        }
    }
}
