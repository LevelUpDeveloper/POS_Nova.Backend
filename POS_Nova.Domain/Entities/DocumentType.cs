using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Domain.Entities
{
    public class DocumentType
    {
        public static DocumentType Crear(string code, string name, string abbreviation, bool isActive)
        {
            return new DocumentType
            {
                Code = code,
                Name = name,
                Abbreviation = abbreviation,
                IsActive = isActive
            };
        }


        public int Id { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Abbreviation { get; private set; }
        public bool IsActive { get; private set; }
    }
}
