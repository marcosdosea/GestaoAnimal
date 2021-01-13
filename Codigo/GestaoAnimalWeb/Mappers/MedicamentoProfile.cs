using AutoMapper;
using Core;
using Models;

namespace Mappers
{
    public class MedicamentoProfile : Profile
    {
        public MedicamentoProfile()
        {
            CreateMap<MedicamentoModel, Medicamento>().ReverseMap();
        }
    }
}
