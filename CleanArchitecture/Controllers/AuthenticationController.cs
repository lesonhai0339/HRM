using CleanArchitecture.Api.Controllers.ResponseTypes;
using CleanArchitecture.Application.Common.Security;
using CleanArchitecture.Application.Customers.Querys.GetAll;
using CleanArchitecture.Application.Customers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CleanArchitecture.Domain.Common.Enums;
using System.Data;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("customer/Getall")]
        [ProducesResponseType(typeof(JsonResponse<List<CusTomerDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [Microsoft.AspNetCore.Authorization.Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<List<CusTomerDto>>> GetAllCustomer(
     CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllCusTomerQuery(), cancellationToken);
            return result;
        }
    }
}
