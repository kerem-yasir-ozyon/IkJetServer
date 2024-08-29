using AutoMapper;
using IkJet.DTO.Concrete;
using IkJet.Entities.Concrete;
using IkJet_Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IkJet_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private IConfiguration _configuration;
        private IMapper _mapper;

        public AuthController(UserManager<AppUser> userManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            _configuration = configuration;
            _mapper = mapper;
        }



        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel kullaniciLoginModel)
        {

            if (!_configuration.GetSection("JwtTokenSettings").Exists())   //appsettings.json 'da 
                return BadRequest("JwtSettings appsettings'de bulunamadi.");

            if (!_configuration.GetSection("JwtTokenSettings:Issuer").Exists())
                return BadRequest("Issuer appsettings'de bulunamadi.");

            if (!_configuration.GetSection("JwtTokenSettings:Audience").Exists())
                return BadRequest("Audience appsettings'de bulunamadi.");

            if (!_configuration.GetSection("JwtTokenSettings:Key").Exists())
                return BadRequest("Key appsettings'de bulunamadi.");


            AppUser currentUser = await _userManager.FindByEmailAsync(kullaniciLoginModel.Email);

            if (currentUser is null)
                return NotFound("Kullanici adi hatalidir.");


            
            var result = await _userManager.CheckPasswordAsync(currentUser, kullaniciLoginModel.Password);
            if (!result)
                return NotFound("Şifre hatalidir.");


            string issuer = _configuration["JwtTokenSettings:Issuer"]; //issuer

            string audience = _configuration.GetSection("JwtTokenSettings:Audience").Value; //audience

            DateTime expirationDate = DateTime.Now.AddMinutes(
                                Convert.ToInt32(_configuration["JwtTokenSettings:Lifetime"])  //lifetime
                                );

            string key = _configuration["JwtTokenSettings:Key"];

            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));   //key


            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, currentUser.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname, currentUser.LastName));
            
            claims.Add(new Claim(ClaimTypes.NameIdentifier, currentUser.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, currentUser.Email));

            claims.Add(new Claim("EmailConfirmed", currentUser.EmailConfirmed.ToString()));
 
            
            var roles = await _userManager.GetRolesAsync(currentUser);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            JwtSecurityToken securityToken = new JwtSecurityToken(issuer, audience, claims, expires: expirationDate, signingCredentials: signingCredentials);


            string token = _jwtSecurityTokenHandler.WriteToken(securityToken);

            return Ok(token);



        }



		//https://localhost:7262/api/Auth/CheckPassword
		[HttpPost("CheckPassword")]
		public async Task<IActionResult> CheckPassword(CheckPasswordModel model)
		{
			var user = await _userManager.FindByIdAsync(model.UserId.ToString());
			if (user == null)
			{
				return NotFound();
			}

			var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);
			return Ok(isPasswordValid);  
		}





	}
}
