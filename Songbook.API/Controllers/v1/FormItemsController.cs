using MediatR;
using Microsoft.AspNetCore.Mvc;
using Songbook.Domain.Exceptions.v1.Common;
using Songbook.Infrastructure.MediatR.v1.Queries;

namespace Songbook.API.Controllers.v1
{
    public class FormItemsController
	{
        [ApiController, Route("api/v{version:apiVersion}/form-items")]
        [ApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrors))]
        public class PriceListsController : ControllerBase
        {
            private readonly IMediator _mediator;

            public PriceListsController(IMediator mediator)
            {
                this._mediator = mediator;
            }

            [HttpGet()]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public async Task<IActionResult> GetAll()
            {
                var result = await _mediator.Send(new GetFormItemsQuery());
                return Ok(result);
            }
        }
    }
}

