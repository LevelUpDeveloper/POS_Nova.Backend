using FluentValidation;
using FluentValidation.Validators;
using POS_Nova.Application.Features.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Application.Features.Products.Validators
{
    public class ProviderRegisterRequestDtoValidator : AbstractValidator<ProviderRegisterRequestDto>
    {
        public ProviderRegisterRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("El Nombre del Provedor es obligatorio");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("El Email del Provedor es obligatorio");

            RuleFor(x => x.DocumentTypeId)
                .NotEmpty()
                .WithMessage("El Documento del Provedor es obligatorio");

            RuleFor(x => x.DocumentNumber)
                .NotEmpty()
                .WithMessage("El Número de Documento del Provedor es obligatorio");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("La Dirección del provedor es obligatoria");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("El número de Teléfono del Provedor es obligatorio");

            RuleFor(x => x.IsActive)
                .NotNull()
                .WithMessage("Debe indicar si el Provedor estara Activado/Desactivado");

        }
    }
}
