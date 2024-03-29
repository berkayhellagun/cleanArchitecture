﻿using AutoMapper;
using Core.Persistence.Paging;
using ReCap.Application.Features.Models.Dtos;
using ReCap.Application.Features.Models.Models;
using ReCap.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCap.Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, ModelListDto>()
                .ForMember(c => c.BrandName, opt => opt.MapFrom(c => c.Brand.Name)).ReverseMap();
            CreateMap<ModelListModel, IPaginate<Model>>().ReverseMap();
        }
    }
}
