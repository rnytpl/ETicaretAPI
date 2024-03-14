using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Please provide a name")
                .MaximumLength(150)
                .MinimumLength(5)
                .WithMessage("Name should be at least 5 characters long");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please provide a stock number")
                .Must(s => s >= 0)
                    .WithMessage("Stock cannot be lower than 0");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please provide a price")
                .Must(s => s >= 0)
                    .WithMessage("Price cannot be lower than 0");
        }
    }
}
