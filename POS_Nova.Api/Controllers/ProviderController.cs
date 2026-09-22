using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS_Nova.Application.Features.Products.DTOs;
using POS_Nova.Application.Features.Products.UseCases;

namespace POS_Nova.Api.Controllers
{
    [Route("api/provider")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        public readonly ProviderRegisterService _providerRegisterService;

        public ProviderController(ProviderRegisterService providerRegisterService)
        {
            _providerRegisterService = providerRegisterService;
        }

        [Authorize(Policy = "CanManagerUser")]
        [HttpPost]
        public async Task<IActionResult> CreateProvider(ProviderRegisterRequestDto providerRegisterRequest)
        {
            var result = await _providerRegisterService.Execute(providerRegisterRequest);
            return Ok(result);
        }
    }
}
