using Microsoft.EntityFrameworkCore;
using POS_Nova.Application.Common;
using POS_Nova.Application.Features.Products.DTOs;
using POS_Nova.Application.Interfaces.Persistence;
using POS_Nova.Domain.Entities;
using POS_Nova.Infrastructure.DataPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace POS_Nova.Infrastructure.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProviderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> ProviderNameNormalizer(string providerName)
        {
            string providerNameNormalizer = TextNormalizer.NormalizeSpaces(providerName);
            providerNameNormalizer = TextNormalizer.ToUpperCase(providerNameNormalizer);
            return providerNameNormalizer;
        }

        public async Task<bool> ProviderNameExists(string providerName)
        {
            bool providerNameExist = await _appDbContext.Provider
                .AnyAsync(c => c.Name == providerName);
            return providerNameExist;
        }

        public async Task<string> ProviderEmailNormalizer(string providerEmail)
        {
            string providerEmailNormalizer = TextNormalizer.NormalizeSpaces(providerEmail);
            providerEmailNormalizer = TextNormalizer.ToLowerCase(providerEmailNormalizer);
            return providerEmailNormalizer;
        }

        public async Task<bool> ProviderEmailExists(string providerEmailNormalized)
        {
            bool providerEmailExist = await _appDbContext.Provider
                .AnyAsync(c => c.Email == providerEmailNormalized);
            return providerEmailExist;
        }

        public async Task<bool> ProviderDocumentExist(int providerDocumentId)
        {
            bool providerDocumentExist = await _appDbContext.DocumentType
                .AnyAsync(c => c.Id == providerDocumentId);
            return providerDocumentExist;
        }

        public async Task<string> ProviderDocumentName(int providerDocumentId)
        {
            return await _appDbContext.DocumentType
                .Where(c => c.Id == providerDocumentId)
                .Select(c => c.Name)
                .FirstOrDefaultAsync() ?? string.Empty;
        }

        public async Task<bool> ProviderPhoneChecker(string providerPhone)
        {
            string providerPhoneNormalized = TextNormalizer.NormalizeSpaces(providerPhone);
            bool providerPhoneExist = await _appDbContext.Provider
                .AnyAsync(c => c.Phone == providerPhoneNormalized);
            return providerPhoneExist;
        }

        public async Task<Provider> ProviderCreateNew(Provider provider)
        {
            await _appDbContext.Provider.AddAsync(provider);
            await _appDbContext.SaveChangesAsync();
            return provider;
        }
    }
}
