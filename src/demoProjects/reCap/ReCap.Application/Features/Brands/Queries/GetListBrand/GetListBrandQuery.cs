using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using ReCap.Application.Features.Brands.Models;
using ReCap.Application.Services.Repositories;
using ReCap.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCap.Application.Features.Brands.Queries.GetListBrand
{
    public class GetListBrandQuery : IRequest<BrandListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, BrandListModel>
        {
            readonly IBrandRepository _brandRepository;
            readonly IMapper _mapper;

            public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<BrandListModel> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Brand> brands = await _brandRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                BrandListModel brandListModel = _mapper.Map<BrandListModel>(brands);
                return brandListModel;
            }
        }
    }
}
