using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS_Nova.Application.Features.Products.DTOs;
using POS_Nova.Application.Features.Products.UseCases;


namespace POS_Nova.Api.Controllers
{
    [Route("api/categoriesRegister")]
    [ApiController]
    public class CategoryRegisterController : ControllerBase
    {
        private readonly CategoryRegisterService _categoryRegisterService;

        public CategoryRegisterController(CategoryRegisterService categoryRegisterService)
        {
            _categoryRegisterService = categoryRegisterService;
        }

        [Authorize(Policy = "CanManageUser")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryRegisterRequestDto categoryRegisterRequestDto) 
        {
            var result = await _categoryRegisterService.Execute(categoryRegisterRequestDto);
            return Ok(result);
        }

    }
}
