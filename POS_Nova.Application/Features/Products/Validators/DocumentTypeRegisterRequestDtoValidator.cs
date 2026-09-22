using FluentValidation;
using POS_Nova.Application.Features.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Application.Features.Products.Validators
{
    public class DocumentTypeRequestDtoValidator : AbstractValidator<DocumentTypeRegisterRequestDto>
    {
        public DocumentTypeRequestDtoValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .WithMessage("El Código del Documento es obligatorio");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("El Nombre del Documento es obligatorio");

            RuleFor(x => x.Abbreviation)
                .NotEmpty()
                .WithMessage("La Abreviación del Documento es obligatoria");

            RuleFor(x => x.IsActive)
                .NotNull()
                .WithMessage("Debe indicar si el Documento estara Activo/Desactivado");
        }
    }
}
