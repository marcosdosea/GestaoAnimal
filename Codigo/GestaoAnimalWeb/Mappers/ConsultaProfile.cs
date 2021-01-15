using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using GestaoAnimalWeb.Models;

namespace GestaoAnimalWeb.Mappers
{
    public class ConsultaProfile: Profile
    {
        public ConsultaProfile()
        {
            CreateMap<ConsultaModel, Consulta>().ReverseMap();
        }

    }
}
