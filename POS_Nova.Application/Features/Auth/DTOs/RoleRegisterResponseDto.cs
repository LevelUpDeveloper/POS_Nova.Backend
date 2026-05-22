using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Application.Features.Auth.DTOs
{
    public record RoleRegisterResponseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
