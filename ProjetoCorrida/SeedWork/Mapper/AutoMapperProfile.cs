using AutoMapper;
using ProjetoCorrida.Dtos.Participante;
using ProjetoCorrida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCorrida.SeedWork.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Participante, CriarParticipanteDto>().ReverseMap();
            CreateMap<Participante, ObterParticipanteDto>().ReverseMap();
            CreateMap<ObterParticipanteDto, CriarParticipanteDto>().ReverseMap();
        }
    }
}
