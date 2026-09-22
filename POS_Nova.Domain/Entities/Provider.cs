using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Domain.Entities
{
    [Table("Provider", Schema = "Purchasing")]
    public class Provider
    {
        public static Provider Create(string name, string email, int documentTypeId, string documentNumber, string address, string phone, bool isActive, DateTime auditCreateDate, int auditCreatedBy)
        {
            return new Provider
            {
                Name = name,
                Email = email,
                DocumentTypeId = documentTypeId,
                DocumentNumber = documentNumber,
                Address = address,
                Phone = phone,
                IsActive = isActive,
                AuditCreateDate = auditCreateDate,
                AuditCreatedBy = auditCreatedBy
            };
        }


        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int DocumentTypeId { get; private set; }
        public string DocumentNumber { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime AuditCreateDate { get; private set; }
        public int AuditCreatedBy { get; private set; }
        public DateTime AuditUpdateDate { get; private set; }
        public int AuditUpdatedBy { get; private set; }
    }
}
