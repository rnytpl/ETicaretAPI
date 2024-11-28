﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        //public string BasketId { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        //public string? User { get; set; }
        //public string? Message { get; set; }
    }
}
