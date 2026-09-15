using POS_Nova.Application.Common;
using POS_Nova.Application.Interfaces.Persistence;
using POS_Nova.Domain.Entities;
using POS_Nova.Infrastructure.DataPersistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Infrastructure.Repositories
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly AppDbContext _appDbContext;

        public DocumentTypeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> DocumentoTypeCodeNormalizer(string documentTypeCode)
        {
            string DocumentoTypeCodeNormalized = TextNormalizer.NormalizeSpaces(documentTypeCode);
            DocumentoTypeCodeNormalized = TextNormalizer.ToUpperCase(DocumentoTypeCodeNormalized);
            return DocumentoTypeCodeNormalized;
        }

        public async Task<bool> DocumentTypeCodeExist(string documentTypeCodeNormalized)
        {
            bool existDocumentTypeCode = await _appDbContext.DocumentType
                                            .AnyAsync(c => c.Code == documentTypeCodeNormalized);
            return existDocumentTypeCode;
        }


        public async Task<string> DocumentTypeNameNormalizer(string documentTypeName)
        {
            string documentTypeNameNormalized = TextNormalizer.NormalizeSpaces(documentTypeName);
            documentTypeNameNormalized = TextNormalizer.ToUpperCase(documentTypeNameNormalized);
            return documentTypeNameNormalized;
        }

        public async Task<bool> DocumentTypeNameExist(string documentTypeNameNormalized)
        {
            bool existDocumentTypeName = await _appDbContext.DocumentType
                                            .AnyAsync(c => c.Name == documentTypeNameNormalized);
            return existDocumentTypeName;
        }


        public async Task<DocumentType> Create(DocumentType documentType)
        {
            await _appDbContext.AddAsync(documentType);
            await _appDbContext.SaveChangesAsync();
            return documentType;
        }
    }
}
