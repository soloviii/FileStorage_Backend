using AutoMapper;
using BLL.Models;
using BLL.Services;
using DAL.Configuration;
using DAL.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FileStorage.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;

        public AccountController(IMapper mapper, UserManager<User> userManager, 
            SignInManager<User> signInManager, IConfiguration config)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UserRegistrationModel userModel)  
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            var user = _mapper.Map<User>(userModel);
            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                return new BadRequestObjectResult(result.Errors);
            }
            await _userManager.AddToRoleAsync(user, Constants.REGISTEREDUSER);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserLoginModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userModel.Email);
                if (user != null)
                {
                    var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, userModel.Password, false);
                    if (passwordCheck.Succeeded)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
                        };
                        var roles = await _userManager.GetRolesAsync(user);
                        var role = roles.FirstOrDefault();

                        claims.Add(new Claim(ClaimTypes.Role, role));

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(claims),
                            Expires = DateTime.UtcNow.AddHours(5),
                            SigningCredentials = credentials
                        };

                        var tokenHandler = new JwtSecurityTokenHandler();
                        var token = tokenHandler.CreateToken(tokenDescriptor);

                        return Ok(new
                        {
                            user.FirstName,
                            user.LastName,
                            user.Email,
                            role,
                            token = tokenHandler.WriteToken(token)
                        });
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
            return BadRequest(new { message = $"Електронна пошта або пароль неправильний"});
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
