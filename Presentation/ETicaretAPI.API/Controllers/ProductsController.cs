using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.RequestParameters;
using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        /// <summary>
        /// For all Get operations we pass bool value of false
        /// No operations other than read is performed on entity(ies)
        /// So it is unnecessary to track states of these entities for better performance
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Pagination pagination)
        {


            var totalPageNum = (double)_productReadRepository.GetAll(false).Count() / pagination.Size;


            var products = _productReadRepository.GetAll(false).Skip((pagination.Page * pagination.Size) - pagination.Size).Take(pagination.Size).Select(p => new
            {
                p.Name,
                p.Price,
                p.Stock,
                p.Id,
                p.CreatedTime,
                p.UpdatedTime
            });

            //new { allProducts = products, pageNumb = Math.Ceiling(totalPagesNum) }
            return Ok(new { allProducts = products, totalPages = Math.Ceiling(totalPageNum) });
            //return Ok(products);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadRepository.GetById(id, false));
        }

        [HttpPost]

        public async Task<IActionResult> Post(VM_Create_Product model)
        {

            if (ModelState.IsValid) { }

            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock,
            });

            await _productWriteRepository.SaveAsync();

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]

        public async Task<IActionResult> Put(Vm_Update_Product model)
        {

            Product product = await _productReadRepository.GetById(model.Id);

            product.Stock = model.Stock;
            product.Price = model.Price;
            product.Name = model.Name;
            await _productWriteRepository.SaveAsync();

            return Ok();
        }

        /// <summary>
        /// Delete method expects an id from request
        /// Takes this id and performs the delete operation on database
        /// Applies those changes by evoking SaveChanges function from dbcontext class
        /// Returns "Ok" with 200 status code
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(string id)
        {
            Console.WriteLine(id);
            Console.WriteLine("New request/delete");
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

    }
}
