using POS_Nova.Application.Exceptions;
using POS_Nova.Application.Features.Products.DTOs;
using POS_Nova.Application.Interfaces.Persistence;
using POS_Nova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Application.Features.Products.UseCases
{
    public class DocumentTypeRegisterService
    {
        public readonly IDocumentTypeRepository _documentTypeRepository;

        public DocumentTypeRegisterService(IDocumentTypeRepository documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;
        }

        public async Task<DocumentTypeRegisterResponseDto> Execute(DocumentTypeRegisterRequestDto documentTypeRegisterRequestDto)
        {

            string documentTypeCodeNormalized = await _documentTypeRepository.DocumentoTypeCodeNormalizer(documentTypeRegisterRequestDto.Code);
            bool existDocumentTypeCode = await _documentTypeRepository.DocumentTypeCodeExist(documentTypeCodeNormalized);

            if (existDocumentTypeCode)
            {
                throw new ConflictException($"Ya se encuentra registrado el código: {documentTypeCodeNormalized}");
            }


            string documentTypeNameNormalized = await _documentTypeRepository.DocumentTypeNameNormalizer(documentTypeRegisterRequestDto.Name);
            bool exitDocumentTypeName = await _documentTypeRepository.DocumentTypeNameExist(documentTypeNameNormalized);

            if (exitDocumentTypeName)
            {
                throw new ConflictException($"Ya se encuentra registrado el nombre: {documentTypeNameNormalized}");
            }

            var documentType = DocumentType.Crear(documentTypeCodeNormalized, documentTypeNameNormalized, documentTypeRegisterRequestDto.Abbreviation, documentTypeRegisterRequestDto.IsActive);

            await _documentTypeRepository.Create(documentType);

            return new DocumentTypeRegisterResponseDto
            {
                Code = documentTypeCodeNormalized,
                Name = documentTypeNameNormalized,
                Abbreviation = documentTypeRegisterRequestDto.Abbreviation,
                IsActive = documentTypeRegisterRequestDto.IsActive
            };

        }
    }
}
