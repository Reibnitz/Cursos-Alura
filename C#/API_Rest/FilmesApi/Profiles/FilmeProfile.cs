using AutoMapper;
using FilmesApi.Data.Dto;
using FilmesAPI.Models;

namespace FilmesApi.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, GetFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}
