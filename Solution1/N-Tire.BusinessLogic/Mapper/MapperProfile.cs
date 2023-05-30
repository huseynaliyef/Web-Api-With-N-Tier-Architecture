using AutoMapper;
using N_Tire.BusinessLogic.Models.DTO.Product;
using N_Tire.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tire.BusinessLogic.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<AddProductUIDTO,Product>().ReverseMap();
        }
    }
}
