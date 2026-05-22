using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS_Nova.Application.Features.Auth.DTOs;
using POS_Nova.Application.Features.Auth.UseCases;

namespace POS_Nova.Api.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleCreateController : ControllerBase
    {
        private readonly RegisterRoleService _registerRoleService;

        public RoleCreateController(RegisterRoleService registerRoleService)
        {
            _registerRoleService = registerRoleService;
        }

        [Authorize(Policy = "CanManageUser")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleRegisterRequestDto roleRegisterRequest)
        {
            var result = await _registerRoleService.Execute(roleRegisterRequest);
            return Ok(result);

        }

    }
}
