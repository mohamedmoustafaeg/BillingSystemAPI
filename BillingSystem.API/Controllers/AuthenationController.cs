using BillingSystem.DataAccess.models.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BillingSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public AuthenationController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser)
        {
            if (registerUser == null)
                return BadRequest();

            //Checking if user exists in database
            var checkUser = await _userManager.FindByEmailAsync(registerUser.Email);
            if (checkUser != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Email already exists");
            }
            IdentityUser user = new()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.Username
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                return StatusCode(201);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            //Check if user exists in db
            var user = await _userManager.FindByNameAsync(loginModel.UserName);

            //Check if password is correct
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var userrole = await _userManager.GetRolesAsync(user);


                //claimlist creation
                var authenticationClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("uid",user.Id),
                    new Claim(ClaimTypes.Email,user.Email),
                    //global user id unique
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                var userRoles = await _userManager.GetRolesAsync(user);
                //Add role to claims
                foreach (var role in userRoles)
                {
                    authenticationClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                //Generate the token with claims 
                var jwtToken = GetToken(authenticationClaims);

                //return the token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    validfrom = jwtToken.ValidFrom,
                    expiration = jwtToken.ValidTo

                });
            }
            return Unauthorized();
        }

        private JwtSecurityToken GetToken(List<Claim> authenticationClaims)
        {
            var authenticationSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var Token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(1).ToLocalTime(),
                    claims: authenticationClaims,
                    signingCredentials: new SigningCredentials(authenticationSigninKey, SecurityAlgorithms.HmacSha256)
                );
            return Token;
        }

    }
}
