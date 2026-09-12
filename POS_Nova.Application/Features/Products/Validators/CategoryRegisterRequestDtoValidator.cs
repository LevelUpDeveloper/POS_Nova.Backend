using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_Nova.Application.Features.Products.DTOs;

namespace POS_Nova.Application.Features.Products.Validators
{
    public class CategoryRegisterRequestDtoValidator : AbstractValidator<CategoryRegisterRequestDto>
    {
        public CategoryRegisterRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("El nombre de la categoría es obligatorio");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("La descripción de la categoría es obligatoria");

            RuleFor(x => x.IsActive)
                .NotNull()
                .WithMessage("Debe indicar si la categoría estara activa/desactivada");
        }
    }
}
