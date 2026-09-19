using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Application.Features.Products.DTOs
{
    public record ProviderRegisterRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentNumber { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public int AuditCreatedBy { get; set; }
        //public DateTime AuditUpdateDate { get; set; }
        //public int AuditUpdatedBy { get; set; }
    }
}
