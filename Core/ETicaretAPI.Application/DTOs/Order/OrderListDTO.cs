using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs.Order
{
    public class OrderListDTO
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public float? TotalPrice { get; set; }
        public string? OrderCode { get; set; }
        public string? UserId { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? UserName { get; set; }
        public List<BasketItem>? BasketItems { get; set; }
    }
}
