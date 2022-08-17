using Core.Persistence.Repositories;
using ReCap.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCap.Application.Services.Repositories
{
    public interface IBrandRepository : IAsyncRepository<Brand>
    {

    }
}
