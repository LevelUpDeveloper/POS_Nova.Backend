using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS_Nova.Application.Features.Products.DTOs;
using POS_Nova.Application.Features.Products.UseCases;


namespace POS_Nova.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRegisterService _categoryRegisterService;

        public CategoryController(CategoryRegisterService categoryRegisterService)
        {
            _categoryRegisterService = categoryRegisterService;
        }

        [Authorize(Policy = "CanManagerUser")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryRegisterRequestDto categoryRegisterRequestDto) 
        {
            var result = await _categoryRegisterService.Execute(categoryRegisterRequestDto);
            return Ok(result);
        }

    }
}
