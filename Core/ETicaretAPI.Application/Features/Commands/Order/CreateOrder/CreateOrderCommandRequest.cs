using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public string Address { get; set; }
        public string BasketId { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }


    }
}
