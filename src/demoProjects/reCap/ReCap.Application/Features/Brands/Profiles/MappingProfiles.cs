using AutoMapper;
using Core.Persistence.Paging;
using ReCap.Application.Features.Brands.Commands.CreateBrand;
using ReCap.Application.Features.Brands.Dtos;
using ReCap.Application.Features.Brands.Models;
using ReCap.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCap.Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        // Automapper class 
        public MappingProfiles()
        {
            CreateMap<Brand, CreatedBrandDto>().ReverseMap();
            // Command hold fields so we can use this map rules
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();
            CreateMap<Brand, BrandListDto>().ReverseMap();
        }
    }
}
