using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using Models;

namespace GestaoAnimalWeb.Mappers
{
    public class AnimalProfile: Profile
    {
        public AnimalProfile()
        {
            CreateMap<AnimalModel, Animal>().ReverseMap();
        }
    }
}
