using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS_Nova.Application.Features.Products.DTOs;
using POS_Nova.Application.Features.Products.UseCases;

namespace POS_Nova.Api.Controllers
{
    [Route("api/controllerRegister")]
    [ApiController]
    public class DocumentTypeRegisterController : ControllerBase
    {
        private readonly DocumentTypeRegisterService _documentTypeRegisterService;

        public DocumentTypeRegisterController(DocumentTypeRegisterService documentTypeRegisterService)
        {
            _documentTypeRegisterService = documentTypeRegisterService;
        }

        [Authorize(Policy = "CanManageUser")]
        [HttpPost]
        public async Task<IActionResult> CreateDocumentType(DocumentTypeRegisterRequestDto documentTypeRegisterRequestDto)
        {
            var result = await _documentTypeRegisterService.Execute(documentTypeRegisterRequestDto);
            return Ok(result);
        }
    }
}
