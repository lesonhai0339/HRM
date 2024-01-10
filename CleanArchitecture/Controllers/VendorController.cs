using CleanArchitecture.Api.Controllers.ResponseTypes;
using CleanArchitecture.Application.Shops.Commands.Create;
using CleanArchitecture.Application.Shops.Commands.Delete;
using CleanArchitecture.Application.Shops.Commands.Update;
using CleanArchitecture.Application.Shops.Querys.GetAll;
using CleanArchitecture.Application.Shops.Querys.GetById;
using CleanArchitecture.Application.Shops;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Vendor;
using CleanArchitecture.Application.Vendor.GetVendors;
using CleanArchitecture.Application.Vendor.CreateVendors;
using CleanArchitecture.Application.Vendor.DeleteVendors;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly ISender _mediator;

        public VendorController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Get")]
        [ProducesResponseType(typeof(JsonResponse<List<VendorDTO>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<VendorDTO>>> GetAllShop(
            Guid id,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetVendorCommand(id), cancellationToken);
            return Ok(result);
        }


        

        [HttpPost("create")]
        [ProducesResponseType(typeof(JsonResponse<VendorDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VendorDTO>> CreateShop(
           [FromBody] CreateVendorCommand command,
         CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpPost("delete")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteShop(
           [FromBody] DeleteVendorCommand command,
         CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result;
        }

        [HttpPost("update")]
        [ProducesResponseType(typeof(JsonResponse<VendorDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VendorDTO>> UpdateShop(
           [FromBody] DeleteVendorCommand command,
         CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }
    }
}
