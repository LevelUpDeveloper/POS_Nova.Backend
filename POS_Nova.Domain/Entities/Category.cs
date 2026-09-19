using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace POS_Nova.Domain.Entities
{
    [Table("Category", Schema = "Inventory")]
    public class Category
    {

        public static Category Create(string name, string description, bool isActive, DateTime auditCreateDate, int auditCreatedBy)
        {
            return new Category
            {
                Name = name,
                Description = description,
                IsActive = isActive,
                AuditCreateDate = auditCreateDate,
                AuditCreatedBy = auditCreatedBy
            };
        }


        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime AuditCreateDate { get; private set; }
        public int AuditCreatedBy { get; private set; }
        public DateTime? AuditUpdateDate { get; private set; }
        public int? AuditUpdatedBy { get; private set; }

    }
}
