using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Application.Features.Products.DTOs
{
    public record ProviderRegisterResponseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string DocumentTypeId { get; set; }
        public string DocumentNumber { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public string AuditCreatedBy { get; set; }
        //public DateTime AuditUpdateDate { get; set; }
        //public int AuditUpdatedBy { get; set; }
    }
}
