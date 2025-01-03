﻿using ETicaretAPI.Application.Abstractions.Storage;
using ETicaretAPI.Application.Consts;
using ETicaretAPI.Application.CustomAttributes;
using ETicaretAPI.Application.Enums;
using ETicaretAPI.Application.Features.Commands.Product.CreateProduct;
using ETicaretAPI.Application.Features.Commands.Product.RemoveProduct;
using ETicaretAPI.Application.Features.Commands.Product.UpdateProduct;
using ETicaretAPI.Application.Features.Commands.ProductImageFile.DeleteProductImage;
using ETicaretAPI.Application.Features.Commands.ProductImageFile.UploadProductImage;
using ETicaretAPI.Application.Features.Queries.Product.GetAllProducts;
using ETicaretAPI.Application.Features.Queries.Product.GetByIdProduct;
using ETicaretAPI.Application.Features.Queries.ProductImageFile.GetAllProductsImages;
using ETicaretAPI.Application.Features.Queries.ProductImageFile.GetProductImages;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.InvoiceFile;
using ETicaretAPI.Application.Repositories.ProductImageFile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        readonly private IStorageService _storageService;
        readonly private IConfiguration _configuration;

        // File operations
        readonly private IProductImageFileReadRepository _productImageFileReadRepository;
        readonly private IProductImageFileWriteRepository _productImageFileWriteRepository;
        readonly private IInvoiceFileReadRepository _invoiceFileReadRepository;
        readonly private IInvoiceFileWriteRepository _invoiceFileWriteRepository;


        readonly IMediator _mediator;
        // Dependency Injections
        public ProductsController(
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            IWebHostEnvironment webHostEnvironment,
            IProductImageFileReadRepository productImageFileReadRepository,
            IProductImageFileWriteRepository productImageFileWriteRepository,
            IInvoiceFileWriteRepository invoiceFileWriteRepository,
            IInvoiceFileReadRepository invoiceFileReadRepository,
            IStorageService storageService,
            IConfiguration configuration,
            IMediator mediator)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _webHostEnvironment = webHostEnvironment;
            _invoiceFileWriteRepository = invoiceFileWriteRepository;
            _invoiceFileReadRepository = invoiceFileReadRepository;
            _productImageFileReadRepository = productImageFileReadRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _storageService = storageService;
            _configuration = configuration;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetAllProductsQueryRequest getAllProductsQueryRequest)
        {
            
           GetAllProductsQueryResponse response = await _mediator.Send(getAllProductsQueryRequest);

            return Ok(response);

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute]GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Writing, Definition = "Add Product")]
        public async Task<CreateProductCommandResponse> Post([FromBody]CreateProductCommandRequest request)
        {
            CreateProductCommandResponse response = await _mediator.Send(request);
            return response;
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Updating, Definition = "Update Product")]
        public async Task<IActionResult> Put(UpdateProductCommandRequest updateProductCommandRequest)
        {

            UpdateProductCommandResponse response = await _mediator.Send(updateProductCommandRequest);


            return Ok(response);
        }

        [HttpDelete("[action]/{id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Deleting, Definition = "Remove Product")]
        public async Task<IActionResult> Remove([FromRoute]RemoveProductCommandRequest removeProductCommandRequest)
        {

            RemoveProductCommandResponse response = await _mediator.Send(removeProductCommandRequest);

            return Ok(response);
        }

        [HttpPost("[action]")]
        [RequestSizeLimit(100_000_000)]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConstants.Baskets, ActionType = ActionType.Writing, Definition = "Upload Product Files")]
        public async Task<IActionResult> Upload([FromQuery] UploadProductImageFileCommandRequest uploadProductImageFileCommandRequest)
        {

            uploadProductImageFileCommandRequest.Files = Request.Form.Files;

            UploadProductImageFileCommandResponse response = await _mediator.Send(uploadProductImageFileCommandRequest);

            return Ok(response);

        }

        [HttpGet("[action]/{productId}")]

        public async Task<IActionResult> GetProductImages([FromRoute] GetProductImagesQueryRequest request)
        {
            List<GetProductImagesQueryResponse> response = await _mediator.Send(request);

            return Ok(response);
            
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetProductsWithImages([FromQuery]GetAllProductsImagesQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete("[action]/{productId}/{imageId}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Deleting, Definition = "Remove Product File")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] DeleteProductImageCommandRequest deleteProductImageCommandRequest)
        {
            DeleteProductImageCommandResponse response = await _mediator.Send(deleteProductImageCommandRequest);

            return Ok(response );
        }

    }
} 