using DAL.Entities;
using DAL.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [Authorize(Roles = Constants.ADMIN_OR_SUPERADMIN)]
        [HttpGet]
        [Route("getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var allUsers = await _userManager.Users.ToListAsync();
            var users = new List<object>();
            foreach (var user in allUsers)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault();
                users.Add(new
                {
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    user.NumberOfFiles,
                    user.SumOfFilesSize,
                    role,
                    user.IsDisabled
                });
            }
            return Ok(users);
        }

        [Authorize]
        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> GetUserById(Guid? id)
        {
            User user = await _userManager.GetUserAsync(User);
            if (id != null)
                if (!(await _userManager.IsInRoleAsync(user, Constants.REGISTEREDUSER)))
                    user = await _userManager.FindByIdAsync(id.ToString());
                else
                    return BadRequest(new { message = $"Користувач '{user.FirstName}' не є адміністратором" });
            if (user is null)
                return NotFound();
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();
            return Ok(new
            {
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                user.NumberOfFiles,
                user.SumOfFilesSize,
                role,
                user.IsDisabled
            });
        }

        [Authorize(Roles = Constants.SUPERADMIN)]
        [HttpPost]
        [Route("addAdmin/{id}")]
        public async Task<IActionResult> MakeUserAdmin(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (await _userManager.IsInRoleAsync(user, Constants.ADMIN_OR_SUPERADMIN))
                return BadRequest(new { message = $"Користувач '{user.FirstName}' вже є адміністратором" });
            await _userManager.RemoveFromRoleAsync(user, Constants.REGISTEREDUSER);
            await _userManager.AddToRoleAsync(user, Constants.ADMINISTRATOR);
            return Ok();
        }

        [Authorize(Roles = Constants.SUPERADMIN)]
        [HttpPost]
        [Route("removeAdmin/{id}")]
        public async Task<IActionResult> RemoveUserFromAdmin(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (await _userManager.IsInRoleAsync(user, Constants.REGISTEREDUSER))
                return BadRequest(new { message = $"Користувач '{user.FirstName}' не є адміністратором" });
            await _userManager.RemoveFromRoleAsync(user, Constants.ADMINISTRATOR);
            await _userManager.AddToRoleAsync(user, Constants.REGISTEREDUSER);
            return Ok();
        }

        [Authorize(Roles = Constants.ADMIN_OR_SUPERADMIN)]
        [HttpPost]
        [Route("enable/{id}")]
        public async Task<IActionResult> Enable(Guid id)
        {
            var sender = await _userManager.GetUserAsync(User);
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (!user.IsDisabled)
                return BadRequest(new { message = $"Користувач '{user.FirstName}' не в чорному списку" });
            if (!await _userManager.IsInRoleAsync(user, Constants.REGISTEREDUSER) &&
                await _userManager.IsInRoleAsync(sender, Constants.ADMINISTRATOR))
                return BadRequest(new { message = $"Адміністратор не може виключити іншого адміністратора з чорного списку" });
            if (sender.Id == user.Id)
                return BadRequest(new { message = $"Супер Адміністратор не може виключити себе з чорного списку" });
            user.IsDisabled = false;
            await _userManager.UpdateAsync(user);
            return Ok();
        }

        [Authorize(Roles = Constants.ADMIN_OR_SUPERADMIN)]
        [HttpPost]
        [Route("disable/{id}")]
        public async Task<IActionResult> Disable(Guid id)
        {
            var sender = await _userManager.GetUserAsync(User);
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user.IsDisabled)
                return BadRequest(new { message = $"Користувач '{user.FirstName}' уже є в чорному списку" });
            if (!await _userManager.IsInRoleAsync(user, Constants.REGISTEREDUSER) &&
                await _userManager.IsInRoleAsync(sender, Constants.ADMINISTRATOR))
                return BadRequest(new { message = $"Адміністратор не може додати іншого адміністратора в чорний список" });
            if (sender.Id == user.Id)
                return BadRequest(new { message = $"Супер Адміністратор не може додати себе в чорний список" });
            user.IsDisabled = true;
            await _userManager.UpdateAsync(user);
            return Ok();
        }

    }
}
