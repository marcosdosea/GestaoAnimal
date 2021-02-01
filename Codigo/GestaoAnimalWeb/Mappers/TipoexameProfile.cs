using AutoMapper;
using Core;
using Models;

namespace Mappers
{
    public class TipoexameProfile : Profile
    {
        public TipoexameProfile()
        {
            CreateMap<TipoexameModel, Tipoexame>().ReverseMap();
        }
    }
}
