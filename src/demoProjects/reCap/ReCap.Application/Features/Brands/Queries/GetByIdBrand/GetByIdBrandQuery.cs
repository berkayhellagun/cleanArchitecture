using AutoMapper;
using MediatR;
using ReCap.Application.Features.Brands.Dtos.BrandDtos;
using ReCap.Application.Features.Brands.Rules;
using ReCap.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCap.Application.Features.Brands.Queries.GetByIdBrand
{
    public class GetByIdBrandQuery : IRequest<BrandGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, BrandGetByIdDto>
        {
            IMapper _mapper;
            IBrandRepository _brandRepository;
            BrandBusinessRules _brandBusinessRules;

            public GetByIdBrandQueryHandler(IMapper mapper, IBrandRepository brandRepository, BrandBusinessRules brandBusinessRules)
            {
                _mapper = mapper;
                _brandRepository = brandRepository;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<BrandGetByIdDto> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
            {
                _brandBusinessRules.BrandShouldExistWhenRequested(request.Id);

                var result = await _brandRepository.GetAsync(b => b.Id == request.Id);
                var brandGetByIdDto = _mapper.Map<BrandGetByIdDto>(result);

                return brandGetByIdDto;
            }
        }
    }
}
