using _365Architect.Demo.Application.Requests.Categories;
using _365Architect.Demo.Application.Requests.Samples;
using _365Architect.Demo.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;


namespace _365Architect.Demo.Presentation.Controllers.v1
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/categories")]
    public class CategoryController : ApiController
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator) { 
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCategoryQuery();
            var result = await _mediator.Send(query);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Error);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) { 
            var query = new GetCategoryByIdQuery()
            {
                Id = id
            };
            var result = await _mediator.Send(query);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Error);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand()
            {
                Id = id
            };
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Error);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryCommand request)
        {
            request.Id = id;
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Error);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Error);
        }


    }
}
