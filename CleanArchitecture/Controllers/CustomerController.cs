using CleanArchitecture.Api.Controllers.ResponseTypes;
using CleanArchitecture.Application.Customers;
using CleanArchitecture.Application.Customers.Commands.Create;
using CleanArchitecture.Application.Orders.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CleanArchitecture.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ISender _mediator;

        public CustomerController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpPost("customer")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CusTomerDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CusTomerDto>> CreateOrder(
            [FromBody] CreateCustomerCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result;
        }
    }
}