using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthJwtInAPI.Model;
using AuthJwtInAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AuthJwtInAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizeController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        public AuthorizeController(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        // GET
        public IActionResult Token(LoginViewModel model)
        {
            if (ModelState.IsValid)
                if (model.UserName == "luna" && model.Password == "123456")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, "luna"),
                        new Claim(ClaimTypes.Role, "admin")
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
                    var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _jwtSettings.Issuer,
                        _jwtSettings.Audience,
                        claims, DateTime.Now,
                        DateTime.Now.AddMinutes(30),
                        cred);
                    return Ok(new {Token = new JwtSecurityTokenHandler().WriteToken(token)});
                }

            return BadRequest();
        }
    }
}