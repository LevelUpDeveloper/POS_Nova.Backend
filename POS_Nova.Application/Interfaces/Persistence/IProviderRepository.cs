using POS_Nova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Application.Interfaces.Persistence
{
    public interface IProviderRepository
    {
        Task<string> ProviderNameNormalizer(string providerName);
        Task<bool> ProviderNameExists(string providerName);
        Task<string> ProviderEmailNormalizer(string providerEmail);
        Task<bool> ProviderEmailExists(string providerEmailNormalizer);
        Task<bool> ProviderDocumentExist(int providerDocument);
        Task<string> ProviderDocumentName(int providerDocumentId);
        Task<bool> ProviderPhoneChecker(string providerPhone);
        Task<Provider> ProviderCreateNew(Provider provider);
    }
}
