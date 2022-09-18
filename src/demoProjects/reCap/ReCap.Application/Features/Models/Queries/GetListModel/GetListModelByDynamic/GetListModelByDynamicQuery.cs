using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ReCap.Application.Features.Models.Models;
using ReCap.Application.Services.Repositories;
using ReCap.Domain.Entities;

namespace ReCap.Application.Features.Models.Queries.GetListModel.GetListModelByDynamic
{
    public class GetListModelByDynamicQuery : IRequest<ModelListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
        public class GetListModelByDynamicQueryHandler : IRequestHandler<GetListModelByDynamicQuery, ModelListModel>
        {
            readonly IModelRepository _modelRepository;
            readonly IMapper _mapper;

            public GetListModelByDynamicQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ModelListModel> Handle(GetListModelByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Model> models = await _modelRepository.GetListByDynamicAsync(
                    dynamic: request.Dynamic,
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
