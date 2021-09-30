using AutoMapper;
using CineGba.Application.Validations;
using CineGba.Domain.Commands;
using CineGba.Domain.Dtos;
using CineGba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGba.Application.Services
{
    public interface IFuncionService
    {
        Funcion CreateFuncion(FuncionDto funcion);
        void DeleteFuncion(Funcion funcion);
        void DeleteFuncionById(int id);
        List<Funcion> GetAllFunciones();
        Funcion GetFuncionById(int id);
        List<Funcion> GetFuncionesByPelicula(int peliculaId);
        List<Funcion> GetFuncionesByPelicula(string titulo);
        List<Funcion> GetFuncionesByFecha(DateTime date);
        List<Funcion> GetFuncionesByFechaAndTitulo(DateTime date, string titulo);
    }
    public class FuncionService : IFuncionService
    {
        IFuncionesRepository _repository;
        IFuncionValidation _validation;
        IMapper _mapper;
        public FuncionService(IFuncionesRepository repository, IFuncionValidation validation, IMapper mapper)
        {
            _repository = repository;
            _validation = validation;
            _mapper = mapper;
        }

        public Funcion CreateFuncion(FuncionDto funcion)
        {
            var funcionMapeada = _mapper.Map<Funcion>(funcion);
            
            if (_validation.ValidarFuncion(funcionMapeada))
            {
                _repository.Add(funcionMapeada);
            }
            else
            {
                funcionMapeada = null;
            }
            
            return funcionMapeada;
        }

        public void DeleteFuncion(Funcion funcion)
        {
            _repository.Delete(funcion);
        }

        public void DeleteFuncionById(int id)
        {
            _repository.DeleteById(id);
        }

        public List<Funcion> GetAllFunciones()
        {
            return _repository.GetAllFunciones();
        }

        public Funcion GetFuncionById(int id)
        {
            return _repository.GetFuncionById(id);
        }

        public List<Funcion> GetFuncionesByFecha(DateTime date)
        {
            return _repository.GetFuncionesByFecha(date);
        }

        public List<Funcion> GetFuncionesByFechaAndTitulo(DateTime date, string titulo)
        {
            return _repository.GetFuncionesByFechaAndTitulo(date, titulo);
        }

        public List<Funcion> GetFuncionesByPelicula(int peliculaId)
        {
            return _repository.GetFuncionesByPelicula(peliculaId);
        }

        public List<Funcion> GetFuncionesByPelicula(string titulo)
        {
            return _repository.GetFuncionesByPelicula(titulo);
        }
    }
}
