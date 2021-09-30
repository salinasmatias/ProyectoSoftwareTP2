using AutoMapper;
using CineGba.Domain.Dtos;
using CineGba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineGba.Presentation
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pelicula, PeliculaDto>();
            CreateMap<Funcion, FuncionDto>().ForMember(FuncionDto => FuncionDto.Fecha, opt => opt.MapFrom(src => src.Fecha.ToString("yyyy-MM-dd")))
                                            .ForMember(FuncionDto => FuncionDto.Horario, opt => opt.MapFrom(src => src.Horario.Value.ToString(@"hh\:mm")));
            CreateMap<FuncionDto, Funcion>();
        }
    }
}
