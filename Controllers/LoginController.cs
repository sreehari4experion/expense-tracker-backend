using ExpenseTrackerNew.Repository.UsersRepo;
using ExpenseTrackerNew.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        // 1. dependency injection for configuration
        private readonly IConfiguration _config;
        private readonly IUserRepo _user;

        // 2. constructor ijection
        public LoginController(IConfiguration config, IUserRepo user)
        {
            _config = config;
            _user = user;
        }
        // 3. HttpPost
        [HttpPost("token")]
        public IActionResult Login([FromBody] UserModel user)
        {
            // checking UnAutherised
            IActionResult response = Unauthorized();

            // Authenticate the User
            var loginUser = AuthenticateUser(user);

            // validate the user and gennerate JWT Token
            if (loginUser != null)
            {
                var tokenString = GenerateJWToken(loginUser);
                response = Ok(new { token = tokenString });
            }
            //return Ok("Hello from API");
            return response;
        }



        // 4. Authenticate user
        private UserModel AuthenticateUser(UserModel userModel)
        {
            UserModel loginUser = null;

            // validate the User Credentials
            // retrieve data from the db
            if (userModel.UserName == "sreehari")
            {
                loginUser = new UserModel
                {
                    UserName = "sreehari",
                    Password = "password"

                };
            }
            return loginUser;
        }

        // 5. Generate JWT token
        private string GenerateJWToken(UserModel loginUser)
        {
            // security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            // signin credental
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // claims -- Role

            // generate token
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],//header
                _config["Jwt:Issuer"],//payload
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]

        [HttpGet("{username}&{password}")]
        public async Task<IActionResult> GetUserbyNameandPassword(string username, string password)
        {



            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //signing credential
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            //generate token
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            expires: DateTime.Now.AddDays(5),
            signingCredentials: credentials);
            var response = Ok(new { token = ' ', employee = ' ' });




            if (ModelState.IsValid)
            {
                try
                {
                    var tokens = new JwtSecurityTokenHandler().WriteToken(token);
                    var emp = await _user.GetUserbyNameandPassword(username, password);
                    response = Ok(new { token = tokens, UserName = emp.UserName, UserPassword = emp.Password });
                    return response;
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
