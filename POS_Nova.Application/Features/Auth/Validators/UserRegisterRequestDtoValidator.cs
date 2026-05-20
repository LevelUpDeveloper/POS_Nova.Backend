using FluentValidation;
using POS_Nova.Application.Features.Auth.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Application.Features.Auth.Validators
{
    public class UserRegisterRequestDtoValidator : AbstractValidator<UserRegisterRequestDto>
    {
        public UserRegisterRequestDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("El nombre de usuario es obligatorio");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("El correo electrónico es obligatorio")
                .EmailAddress()
                .WithMessage("El correo electrónico no es válido");

            RuleFor(x => x.ConfirmEmail)
                .NotEmpty()
                .WithMessage("La confirmación del correo electrónico es obligatoria")
                .Equal(x => x.Email)
                .WithMessage("Los correos electrónicos no coinciden");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("La contraseña es obligatoria");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage("La confirmación de la contraseña es obligatoria")
                .Equal(x => x.Password)
                .WithMessage("Las contraseñas no coinciden");

            RuleFor(x => x.Role)
                .NotEmpty()
                .WithMessage("El rol es obligatorio");
        }
    }
}
