using FluentValidation;
using POS_Nova.Application.Features.Auth.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Application.Features.Auth.Validators
{
    internal class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
    {
    }
}
