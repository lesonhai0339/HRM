using CleanArchitecture.Api.Controllers.ResponseTypes;
using CleanArchitecture.Application.Customers;
using CleanArchitecture.Application.Customers.Commands.Create;
using CleanArchitecture.Application.Customers.Commands.Delete;
using CleanArchitecture.Application.Customers.Commands.Update;
using CleanArchitecture.Application.Customers.Querys.GetAll;
using CleanArchitecture.Application.Customers.Querys.GetById;
using CleanArchitecture.Application.Orders;
using CleanArchitecture.Application.Orders.CreateOrder;
using CleanArchitecture.Application.Orders.GetOrderById;
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
        [HttpPost("customer/create")]
        [ProducesResponseType(typeof(JsonResponse<CusTomerDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CusTomerDto>> CreateCustomer(
            [FromBody] CreateCustomerCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result;
        }
        [HttpPost("customer/update")]
        [ProducesResponseType(typeof(JsonResponse<CusTomerDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CusTomerDto>> Updatecustomer(
           [FromBody] UpdateCustomerCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result;
        }
        [HttpPost("customer/delete")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteCustomer(
          [FromBody] DeleteCustomerCommand command,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result;
        }
        [HttpGet("customer/{Id}")]
        [ProducesResponseType(typeof(JsonResponse<CusTomerDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CusTomerDto>> GetCustomerById(
            [FromRoute] Guid Id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetCustomerByIdQuery(id: Id), cancellationToken);
            return result;
        }
        [HttpGet("customer/Getall")]
        [ProducesResponseType(typeof(JsonResponse<List<CusTomerDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<CusTomerDto>>> GetAllCustomer(
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllCusTomerQuery(), cancellationToken);
            return result;
        }
    }
}