using Core.Persistence.Repositories;
using ReCap.Application.Services.Repositories;
using ReCap.Domain.Entities;
using ReCap.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCap.Persistence.Repositories
{
    public class BrandRepository : EfRepositoryBase<Brand, BaseDbContext>, IBrandRepository
    {
        public BrandRepository(BaseDbContext baseDbContext) : base(baseDbContext)
        {

        }
    }
}
