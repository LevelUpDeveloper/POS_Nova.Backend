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


        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public int AuditCreatedBy { get; set; }
        public DateTime? AuditUpdateDate { get; set; }
        public int? AuditUpdatedBy { get; set; }

    }
}
