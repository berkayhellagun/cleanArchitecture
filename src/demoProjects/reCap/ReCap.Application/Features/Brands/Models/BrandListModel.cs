using Core.Persistence.Paging;
using ReCap.Application.Features.Brands.Dtos.BrandDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCap.Application.Features.Brands.Models
{
    public class BrandListModel : BasePageableModel
    {
        public IList<BrandListDto> Items { get; set; }
    }
}
