﻿using ETicaretAPI.Application.Features.Commands.Product.UpdateProduct;
using FluentValidation;

namespace ETicaretAPI.Application.Validators.Products
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductValidator()
        {
            RuleFor(p => p.Name)
                            .NotEmpty()
                            .NotNull()
                                .WithMessage("Enter a valid name")
                            .MaximumLength(100)
                            .MinimumLength(5)
                                .WithMessage("Enter a name between 5-150 characters");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please enter a valid number")
                .Must(s => s >= 0)
                    .WithMessage("Enter a positive number starting from 0");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Enter a valid number")
                .Must(s => s >= 0)
                    .WithMessage("Enter a positive number starting from 0");
        }
    }
}
