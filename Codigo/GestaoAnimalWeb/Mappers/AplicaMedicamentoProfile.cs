using AutoMapper;
using Models;
using Core;

namespace Mappers
{
    public class AplicaMedicamentoProfile : Profile
    {
        public AplicaMedicamentoProfile()
        {
            CreateMap<AplicaMedicamentoModel, AplicaMedicamento>().ReverseMap();
        }
    }
}
