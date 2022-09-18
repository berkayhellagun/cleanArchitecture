using Core.Persistence.Repositories;
using ReCap.Application.Services.Repositories;
using ReCap.Domain.Entities;
using ReCap.Persistence.Context;

namespace ReCap.Persistence.Repositories
{
    public class ModelRepository : EfRepositoryBase<Model, BaseDbContext>, IModelRepository
    {
        public ModelRepository(BaseDbContext baseDbContext) : base(baseDbContext)
        {

        }
    }
}
