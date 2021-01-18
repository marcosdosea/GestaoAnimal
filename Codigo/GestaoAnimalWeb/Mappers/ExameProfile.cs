using AutoMapper;
using Core;
using Models;

namespace Mappers
{
    public class ExameProfile : Profile
    {
        public ExameProfile()
        {
            CreateMap<ExameModel, Exame>().ReverseMap();
        }
    }
}