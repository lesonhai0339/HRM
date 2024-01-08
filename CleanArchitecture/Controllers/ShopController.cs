using CleanArchitecture.Api.Controllers.ResponseTypes;
using CleanArchitecture.Application.Customers.Querys.GetAll;
using CleanArchitecture.Application.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Shops;
using CleanArchitecture.Application.Shops.Querys.GetAll;
using MediatR;
using CleanArchitecture.Application.Shops.Querys.GetById;
using CleanArchitecture.Application.Shops.Commands.Create;
using CleanArchitecture.Application.Shops.Commands.Delete;
using CleanArchitecture.Application.Shops.Commands.Update;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ISender _mediator;

        public ShopController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Getall")]
        [ProducesResponseType(typeof(JsonResponse<List<ShopDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ShopDto>>> GetAllShop(
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllShopQuery(), cancellationToken);
            return result;
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(JsonResponse<ShopDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ShopDto>> GetShopById(
            [FromRoute] Guid Id,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetShopByIdQuery(Id), cancellationToken);
            return result;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(JsonResponse<ShopDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ShopDto>> CreateShop(
           [FromBody] CreateShopCommand command,
         CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result;
        }

        [HttpPost("delete")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteShop(
           [FromBody] DeleteShopCommand command,
         CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result;
        }

        [HttpPost("update")]
        [ProducesResponseType(typeof(JsonResponse<ShopDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ShopDto>> UpdateShop(
           [FromBody] UpdateShopCommand command,
         CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result;
        }
    }
}
