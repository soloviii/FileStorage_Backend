using BLL.Services;
using DAL.Configuration;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LimitController : ControllerBase
    {
        private readonly ILimitService _limitService;
        private readonly UserManager<User> _userManager;
        public LimitController(ILimitService limitService, UserManager<User> userManager)
        {
            _limitService = limitService;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet]
        [Route("getLimits/{id?}")]
        public async Task<IActionResult> GetLimitByUserId(Guid? id)
        {
            var user = await _userManager.GetUserAsync(User); 
            if (id is null)
                return Ok(_limitService.GetLimits(Guid.Parse(user.Id)));

            bool isAdmin = await _userManager.IsInRoleAsync(user, Constants.ADMINISTRATOR) ||
                await _userManager.IsInRoleAsync(user, Constants.SUPERADMIN);
            if (Guid.Parse(user.Id) == id || isAdmin)
                return Ok(_limitService.GetLimits(id));
            return BadRequest(new { message = $"Зареєстрований користувач `{user.FirstName}` може переглядати тільки свої ліміти на файли" });

            /*var user = await _userManager.GetUserAsync(User);
            if (id is null)
                return Ok(_limitService.GetLimits(Guid.Parse(user.Id)));

            bool isAdmin = await _userManager.IsInRoleAsync(user, Constants.ADMINISTRATOR) ||
                await _userManager.IsInRoleAsync(user, Constants.SUPERADMIN);
            if (Guid.Parse(user.Id) == id || isAdmin)
                return Ok(_limitService.GetLimits(id));
            return BadRequest(new { message = $"Зареєстрований користувач `{user.FirstName}` може переглядати тільки свої ліміти на файли" });*/
        }

        [Authorize(Roles = Constants.ADMIN_OR_SUPERADMIN)]
        [HttpPost]
        public IActionResult CreateOrUpdateLimits([FromBody] UserLimit userLimit)
        {
            _limitService.CreateOrUpdateLimitForUser(userLimit);
            return Ok();
        }

        [Authorize(Roles = Constants.ADMIN_OR_SUPERADMIN)]
        [HttpPost]
        [Route("removeLimits/{id}")]
        public IActionResult RemoveLimits(Guid id)
        {
            var isRemove = _limitService.RemoveLimit(id);
            if (!isRemove)
                return BadRequest(new { message = $"Немає конкретних обмежень для користувача з таким ідентифікатором - {id}" });
            return Ok();
        }
    }
}
