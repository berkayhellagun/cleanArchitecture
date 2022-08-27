using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReCap.Application.Features.Brands.Commands.CreateBrand;
using ReCap.Application.Features.Brands.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            var result = await Mediator.Send(createBrandCommand);
            return Created("Created", result);
        }
    }
}
