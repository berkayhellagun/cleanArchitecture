using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReCap.Application.Features.Brands.Commands.CreateBrand;
using ReCap.Application.Features.Brands.Dtos;
using ReCap.Application.Features.Brands.Queries.GetByIdBrand;
using ReCap.Application.Features.Brands.Queries.GetListBrand;

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

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListBrandQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBrandQuery getByIdBrandQuery)
        {
            var result = await Mediator.Send(getByIdBrandQuery);
            return Ok(result);
        }
    }
}
