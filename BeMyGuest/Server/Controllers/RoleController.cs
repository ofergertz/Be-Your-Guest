using Infrastructure.Model.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeMyGuest.Server.Controllers
{
    [ApiController]
    [Route("api/Roles")]
    public class RoleController : ControllerBase
    {
        private readonly IGetRolesService _getRolesService ;

        public RoleController(IGetRolesService getRolesService)
        {
            _getRolesService = getRolesService;
        }
        /// <summary>
        /// Get Roles exist in the system
        /// </summary>
        /// <returns>Status 200 OK</returns>
        [HttpGet]
        [Route("GetRoles")]
        public async Task<ActionResult> GetRoles()
        {
            var response = await _getRolesService.GetRoles();
            return Ok(response);
        }
    }
}
