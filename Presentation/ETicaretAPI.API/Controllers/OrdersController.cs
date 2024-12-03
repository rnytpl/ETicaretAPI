using ETicaretAPI.Application.Features.Commands.Order.CreateOrder;
using ETicaretAPI.Application.Features.Queries.Order.GetOrderById;
using ETicaretAPI.Application.Features.Queries.Order.GetOrders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Admin")]

        public async Task<IActionResult> GetOrders([FromQuery]GetOrdersQueryRequest request)
        {
           var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("{orderId}")]
        [Authorize(AuthenticationSchemes = "Admin")]

        public async Task<IActionResult> GetOrderById([FromRoute]GetOrderByIdQueryRequest request)
        {
            GetOrderByIdQueryResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]

        public async Task<IActionResult> CreateOrder([FromBody]CreateOrderCommandRequest request)
        {
            CreateOrderCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateOrder()
        {
            return Ok();
        }


        [HttpDelete]

        public async Task<IActionResult> RemoveOrder()
        {
            return Ok();
        }

    }
}
