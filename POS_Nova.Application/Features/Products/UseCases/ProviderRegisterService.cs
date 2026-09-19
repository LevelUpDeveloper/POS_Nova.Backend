using POS_Nova.Application.Interfaces.Persistence;
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

        public ProviderRegisterService(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }


    }
}
