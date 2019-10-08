using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BLL.UserAccount;
using DataAccessLayer.AccessModel;
using DataAccessLayer.FactoryShoppingModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FactoryShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository loginService;
        private IConfiguration _config;
        public LoginController(ILoginRepository _loginService, IConfiguration config)
        {
            loginService = _loginService;
            _config = config;
        }

        private string GenerateJSONWebToken(int role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(ClaimTypes.Role,role.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        // POST: api/Login
        [HttpPost]
        public IActionResult Post([FromBody] Login value)
        {
            var roleId = loginService.checkUser(value);
            var user = loginService.getUserId(value);
            if(roleId != 0)
            {
                var tokenstring = GenerateJSONWebToken(roleId);
                return Ok(new { token = tokenstring, role = roleId, userId = user});
            }
            else
            return BadRequest(new { message = "Username & Password is Incorrect"});
         }
        [HttpPost("guestbyGoogle")]
        public IActionResult velaByGoogle([FromBody] Login input)
        {
            var roleId = loginService.googleLogin(input);
            var user = loginService.getUserId(input);
            if (roleId != 0)
            {
                var tokenstring = GenerateJSONWebToken(roleId);
                return Ok(new { token = tokenstring, role = roleId, userId = user });
            }
            else
                return BadRequest(new { message = "Username & Password is Incorrect" });
        }

       
    

    }
}
