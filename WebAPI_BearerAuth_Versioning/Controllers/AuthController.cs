using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI_BearerAuth_Versioning.Models;

namespace WebAPI_BearerAuth_Versioning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("token")]
        public IActionResult CreateToken([FromBody] LoginModel user)
        {
            if (user == null) return BadRequest("Invalid client request.");

            if (user.UserName == "admin" && user.Password == "admin")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, "Manager")
                };

                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signingCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(tokenString);
            }

            return Unauthorized();
        }
    }
}
