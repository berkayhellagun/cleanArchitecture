using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using ReCap.Application.Services.Repositories;
using ReCap.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCap.Application.Features.Brands.Rules
{
    public class BrandBusinessRules
    {
        private readonly IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        internal async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Brand> result = await _brandRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any())
            {
                throw new BusinessException("Brand name exist!");
            }
        }

        internal async Task BrandShouldExistWhenRequested(int id)
        {
            var result = await _brandRepository.GetAsync(b => b.Id == id);
            if (result == null)
            {
                throw new BusinessException("Requested brand does not exist!");
            }
        }
    }
}
