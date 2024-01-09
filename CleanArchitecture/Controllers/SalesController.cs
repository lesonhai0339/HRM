using CleanArchitecture.Api.Controllers.ResponseTypes;
using CleanArchitecture.Application.Sale;
using CleanArchitecture.Application.Sales.CreateSale;
using CleanArchitecture.Application.Sales.DeleteSale;
using CleanArchitecture.Application.Sales.GetSales;
using CleanArchitecture.Application.Sales.UpdateSale;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISender _mediator;

        public SalesController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("sales")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<Guid>>> CreateSale(
            [FromBody] CreateSaleCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(Created), new JsonResponse<Guid>(result));
        }

        [HttpGet("sales/{customerId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<SaleDto>>> GetSales(
            [FromRoute] Guid customerId,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetSalesQuery(customerId), cancellationToken);
            return Ok(result);
        }

        [HttpPut("sales/{saleId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateSale(
            [FromRoute] Guid saleId,
            [FromBody] UpdateSaleCommand command,
            CancellationToken cancellationToken = default)
        {
            if (command.SaleId == default)
            {
                command.SaleId = saleId;
            }

            if (saleId != command.SaleId)
            {
                return BadRequest();
            }

            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("sales/{saleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteSale(
            [FromRoute] Guid saleId,
            CancellationToken cancellationToken = default)
        {
            await _mediator.Send(new DeleteSaleCommand(saleId), cancellationToken);
            return Ok();
        }
    }
}
