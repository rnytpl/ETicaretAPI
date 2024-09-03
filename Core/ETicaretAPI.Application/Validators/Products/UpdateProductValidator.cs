using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class UpdateProductValidator : AbstractValidator<VM_Update_Product>
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
