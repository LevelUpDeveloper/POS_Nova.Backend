using POS_Nova.Application.Exceptions;
using POS_Nova.Application.Features.Products.DTOs;
using POS_Nova.Application.Interfaces.Persistence;
using POS_Nova.Application.Interfaces.Services;
using POS_Nova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Application.Features.Products.UseCases
{
    public class ProviderRegisterService
    {
        private readonly IProviderRepository _providerRepository;
        private readonly ICurrentUserService _currentUserService;

        public ProviderRegisterService(IProviderRepository providerRepository, ICurrentUserService currentUserService)
        {
            _providerRepository = providerRepository;
            _currentUserService = currentUserService;
        }

        public async Task<ProviderRegisterResponseDto> Execute(ProviderRegisterRequestDto providerRegisterRequestDto)
        {
            string providerNameNormalized = await _providerRepository.ProviderNameNormalizer(providerRegisterRequestDto.Name);
            bool providerNameExist = await _providerRepository.ProviderNameExists(providerNameNormalized);
            if (providerNameExist)
            {
                throw new ConflictException($"Ya se encuentra registrado el Provedor: {providerNameNormalized}");
            }


            string providerEmailNormalized = await _providerRepository.ProviderEmailNormalizer(providerRegisterRequestDto.Name);
            bool providerEmailExist = await _providerRepository.ProviderEmailExists(providerEmailNormalized);
            if (providerEmailExist)
            {
                throw new ConflictException($"Ya se encuentra registrado el Email: {providerEmailNormalized}");
            }

            bool providerDocumentExist = await _providerRepository.ProviderDocumentExist(providerRegisterRequestDto.DocumentTypeId);
            if (!providerDocumentExist)
            {                
                throw new ConflictException($"No se encuentra registrado el Documento: {providerRegisterRequestDto.DocumentTypeId}");
            }
            string providerDocumentName = await _providerRepository.ProviderDocumentName(providerRegisterRequestDto.DocumentTypeId);

            bool providerPhoneExists = await _providerRepository.ProviderPhoneChecker(providerRegisterRequestDto.Phone);
            if (providerPhoneExists)
            {
                throw new ConflictException($"Ya se encuentra registrado ese número de Telefono: { providerRegisterRequestDto.Phone }");
            }

            var provider = Provider.Create(providerNameNormalized, providerEmailNormalized, providerRegisterRequestDto.DocumentTypeId, providerRegisterRequestDto.DocumentNumber, providerRegisterRequestDto.Address, providerRegisterRequestDto.Phone, providerRegisterRequestDto.IsActive, DateTime.Now, _currentUserService.UserId);

            await _providerRepository.ProviderCreateNew(provider);

            return new ProviderRegisterResponseDto
            {
                Name = providerNameNormalized,
                Email = providerEmailNormalized,
                DocumentTypeId = providerDocumentName,
                DocumentNumber = providerRegisterRequestDto.DocumentNumber,
                Address = providerRegisterRequestDto.Address,
                Phone = providerRegisterRequestDto.Phone,
                IsActive = providerRegisterRequestDto.IsActive,
                AuditCreateDate = provider.AuditCreateDate,
                AuditCreatedBy = _currentUserService.UserName
            };

;        }
    }
}
