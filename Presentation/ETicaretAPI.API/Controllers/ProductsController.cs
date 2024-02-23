using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository;
        readonly private ICustomerReadRepository _customerReadRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, ICustomerWriteRepository customerWriteRepository, ICustomerReadRepository customerReadRepository ,IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            
            _customerWriteRepository = customerWriteRepository;
            _customerReadRepository = customerReadRepository;

            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {

            //Guid id = Guid.NewGuid();

            //await _productWriteRepository.AddAsync(new Product() { Name = "A Product", Price = 500, Stock = 15, });

            //await _customerWriteRepository.AddAsync(new Customer() {Id = id, Name = "Hakan" });


            //await _orderWriteRepository.AddRangeAsync(new() { new() {Address = "Asdasdas", Description = "adsasdasdasd", CustomerId = id,  } });

            //await _customerWriteRepository.SaveAsync();

            var o = await _orderReadRepository.GetById("3057c2bb-7e06-4685-b0b7-0b8eb5dfcdc5");

            o.Address = "Eraykent Sitesi, Maltepe/İstanbul";

            await _orderWriteRepository.SaveAsync();

        }


    }
}
