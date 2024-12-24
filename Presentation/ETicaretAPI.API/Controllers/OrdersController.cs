using ETicaretAPI.Application.Consts;
using ETicaretAPI.Application.CustomAttributes;
using ETicaretAPI.Application.Enums;
using ETicaretAPI.Application.Features.Commands.Order.CompleteOrder;
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
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Reading, Definition = "Get Orders")]
        public async Task<IActionResult> GetOrders([FromQuery]GetOrdersQueryRequest request)
        {
           var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("{orderId}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Reading, Definition = "Get Order By Id ")]
        public async Task<IActionResult> GetOrderById([FromRoute]GetOrderByIdQueryRequest request)
        {
            GetOrderByIdQueryResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Writing, Definition = "Create Order")]
        public async Task<IActionResult> CreateOrder([FromBody]CreateOrderCommandRequest request)
        {
            CreateOrderCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("complete-order")]
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Updating, Definition = "Complete Order")]
        public async Task<IActionResult> CompleteOrder([FromQuery]CompleteOrderCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        //[HttpPut]

        //public async Task<IActionResult> UpdateOrder()
        //{
        //    return Ok();
        //}


        //[HttpDelete]

        //public async Task<IActionResult> RemoveOrder()
        //{
        //    return Ok();
        //}

    }
}
