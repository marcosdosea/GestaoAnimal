using AutoMapper;
using Models;
using Core;

namespace Mappers
{
    public class AgendamedicamentoProfile : Profile
    {
        public AgendamedicamentoProfile()
        {
            CreateMap<AgendamedicamentoProfile, Agendamedicamento>().ReverseMap();
        }
    }
}
