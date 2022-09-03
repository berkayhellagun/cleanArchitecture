using AutoMapper;
using MediatR;
using ReCap.Application.Features.Brands.Dtos.BrandDtos;
using ReCap.Application.Features.Brands.Rules;
using ReCap.Application.Services.Repositories;
using ReCap.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCap.Application.Features.Brands.Commands.CreateBrand
{
    // IRequest out parameter is EntityDto
    public class CreateBrandCommand : IRequest<CreatedBrandDto>
    {
        // Command Fields:
        public string Name { get; set; }

        // Request Handler
        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandDto>
        {
            // Repository
            private readonly IBrandRepository _brandRepository;
            // Automapper
            private readonly IMapper _mapper;
            // Business Rule
            private readonly BrandBusinessRules _rules;

            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules rules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await _rules.BrandNameCanNotBeDuplicatedWhenInserted(name: request.Name);

                var brandObj = _mapper.Map<Brand>(request);
                var dbObj = await _brandRepository.AddAsync(brandObj);
                var createdBrandDto = _mapper.Map<CreatedBrandDto>(dbObj);
                
                return createdBrandDto;
            }
        }
    }
}
