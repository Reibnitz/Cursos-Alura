﻿using AutoMapper;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(dto => dto.HorarioDeInicio, opts => opts
                .MapFrom(dto => dto.HorarioDeEncerramento.AddMinutes(-1 * dto.Filme.Duracao)));
        }
    }
}
