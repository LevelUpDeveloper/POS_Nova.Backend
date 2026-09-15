using POS_Nova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Application.Interfaces.Persistence
{
    public interface IDocumentTypeRepository
    {
        Task<string> DocumentoTypeCodeNormalizer(string documentTypeCode);
        Task<bool> DocumentTypeCodeExist(string documentTypeCode);

        Task<string> DocumentTypeNameNormalizer(string documentTypeName);
        Task<bool> DocumentTypeNameExist(string documentTypeName);

        Task<DocumentType> Create(DocumentType documentType);
    }
}
