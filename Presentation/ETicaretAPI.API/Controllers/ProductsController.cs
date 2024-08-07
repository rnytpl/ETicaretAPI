﻿using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.RequestParameters;
using ETicaretAPI.Application.Services;
using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // Referencing services to be injected in IoC
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        readonly private IWebHostEnvironment _webHostEnvironment;
        readonly private IFileService _fileService;
        // Referencing FluentValidation service
        readonly private IValidator<VM_Create_Product> _createProductValidator;
        readonly private IValidator<VM_Update_Product> _updateProductValidator;

        // Injecting those dependencies through constructor
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository,IValidator<VM_Create_Product> createProductValidator, IValidator<VM_Update_Product> updateProductValidator, IWebHostEnvironment webHostEnvironment, IFileService fileService)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;

            _createProductValidator = createProductValidator;
            _updateProductValidator = updateProductValidator;

            _webHostEnvironment = webHostEnvironment;

            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]Pagination pagination)
        {
            var totalCount = _productReadRepository.GetAll(false).Count();
            var products = _productReadRepository.GetAll(false).Select(p => new
            {
                p.Id,
                p.Name,
                p.Stock,
                p.Price,
                p.CreatedDate,
                p.UpdatedDate,
            }).Skip((pagination.Page - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();

            decimal page = (decimal)totalCount / pagination.PageSize;
            var totalPages = Math.Ceiling(page);

            return Ok(new  { 
                products,
                totalPages,
                totalCount
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {

            ValidationResult validationResult = _createProductValidator.Validate(model);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            ValidationResult validationResult = _updateProductValidator.Validate(model);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors) ;
            }

            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Name = model.Name;
            product.Price = model.Price;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPost("[action]")]
        [RequestSizeLimit(100_000_000)]
        //[FromBody]IFormFile form
        public async Task<IActionResult> Upload()
        {

            // Check if directory exists, create if not
            // Loop over each file uploaded
            // Name each file with a random numb
            // Create a stream
            // Copy from stream
            // Flush stream

            await _fileService.UploadAsync("resource/product-images", Request.Form.Files);

            return Ok();

        }
    }

}