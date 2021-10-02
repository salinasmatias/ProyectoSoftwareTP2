using AutoMapper;
using CineGba.Domain.Dtos;
using CineGba.Domain.Entities;

namespace CineGba.Presentation
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pelicula, PeliculaDto>();
            CreateMap<PeliculaDto, Pelicula>();
            CreateMap<Funcion, FuncionDto>().ForMember(FuncionDto => FuncionDto.Fecha, opt => opt.MapFrom(src => src.Fecha.ToString("yyyy-MM-dd")))
                                            .ForMember(FuncionDto => FuncionDto.Horario, opt => opt.MapFrom(src => src.Horario.Value.ToString(@"hh\:mm")));
            CreateMap<FuncionDto, Funcion>();
            CreateMap<Ticket, TicketDtoForCreation>();
        }
    }
}
