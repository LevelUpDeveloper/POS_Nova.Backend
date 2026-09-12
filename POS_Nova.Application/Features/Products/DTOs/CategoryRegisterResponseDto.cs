using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Application.Features.Products.DTOs
{
    public record CategoryRegisterResponseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public string AuditCreatedBy { get; set; }
    }
}
