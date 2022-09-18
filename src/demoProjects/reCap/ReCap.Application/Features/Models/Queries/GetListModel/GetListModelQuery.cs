using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ReCap.Application.Features.Models.Models;
using ReCap.Application.Services.Repositories;
using ReCap.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCap.Application.Features.Models.Queries.GetListModel
{
    public class GetListModelQuery : IRequest<ModelListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, ModelListModel>
        {
            readonly IModelRepository _modelRepository;
            readonly IMapper _mapper;

            public GetListModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ModelListModel> Handle(GetListModelQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Model> models = await _modelRepository.GetListAsync(
                    include:
                    m => m.Include(c => c.Brand),
                    index: request.PageRequest.Page, 
                    size: request.PageRequest.PageSize
                    );

                ModelListModel mapModel = _mapper.Map<ModelListModel>(models);
                return mapModel;
            }
        }
    }
}
