using AutoMapper;
using CineGba.Application.Validations;
using CineGba.Domain.Commands;
using CineGba.Domain.Dtos;
using CineGba.Domain.Entities;
using System;
using System.Collections.Generic;

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
        int GetTicketsDisponiblesByFuncion(int funcionId);
    }
    public class FuncionService : IFuncionService
    {
        private readonly IFuncionesRepository _funcionesRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IFuncionValidation _validation;
        private readonly IMapper _mapper;
        
        public FuncionService(IFuncionesRepository funcionesRepository, ITicketRepository ticketRepository, IFuncionValidation validation, IMapper mapper)
        {
            _funcionesRepository = funcionesRepository;
            _ticketRepository = ticketRepository;
            _validation = validation;
            _mapper = mapper;
        }

        public Funcion CreateFuncion(FuncionDto funcion)
        {
            var funcionMapeada = _mapper.Map<Funcion>(funcion);
            
            if (_validation.ValidarFecha(funcionMapeada))
            {
                _funcionesRepository.Add(funcionMapeada);
            }
            else
            {
                return null;
            }
            
            return funcionMapeada;
        }

        public void DeleteFuncion(Funcion funcion)
        {
            _funcionesRepository.Delete(funcion);
        }

        public void DeleteFuncionById(int id)
        {
            _funcionesRepository.DeleteById(id);
        }

        public List<Funcion> GetAllFunciones()
        {
            return _funcionesRepository.GetAllFunciones();
        }

        public Funcion GetFuncionById(int id)
        {
            return _funcionesRepository.GetFuncionById(id);
        }

        public List<Funcion> GetFuncionesByFecha(DateTime date)
        {
            return _funcionesRepository.GetFuncionesByFecha(date);
        }

        public List<Funcion> GetFuncionesByFechaAndTitulo(DateTime date, string titulo)
        {
            return _funcionesRepository.GetFuncionesByFechaAndTitulo(date, titulo);
        }

        public List<Funcion> GetFuncionesByPelicula(int peliculaId)
        {
            return _funcionesRepository.GetFuncionesByPelicula(peliculaId);
        }

        public List<Funcion> GetFuncionesByPelicula(string titulo)
        {
            return _funcionesRepository.GetFuncionesByPelicula(titulo);
        }

        public int GetTicketsDisponiblesByFuncion(int funcionId)
        {
            return _ticketRepository.GetTicketsDisponiblesByFuncion(funcionId);
        }
    }
}
