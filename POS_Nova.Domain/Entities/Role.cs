using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Domain.Entities
{
    [Table("Role", Schema = "Security")]
    public class Role
    {
        public static Role Create(string name, string description)
        {
            return new Role
            {
                Name = name,
                Description = description,
                IsActive = true
            };
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; private set; }
    }
}
