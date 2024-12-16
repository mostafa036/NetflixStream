using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetflixStream.Application.DTOs.Users;
using NetflixStream.Application.IServices;
using NetflixStream.Domain.UserIdentity;
using NetflixStream.Persistence.Errors;
using System.Security.Claims;

namespace NetflixStream.WebAPIs.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenServices _token;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(
            UserManager<User> userManager ,
            SignInManager<User> signInManager , 
            ITokenServices token ,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _token = token;
            _roleManager = roleManager;
        }


        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized(new ApiResponse(401));

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!signInResult.Succeeded) return Unauthorized(new ApiResponse(401));

            return Ok(new UserDto(user.DisplayName, loginDto.Email,await _token.CreateToken(user ,_userManager)));
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if(CheckEmailExists(registerDto.Email).Result.Value) 
                return BadRequest(new ApiValidationErrorResponse() { Errors = new[] {" this email aready eaxit"}} );

            var visitorRole = await _roleManager.FindByNameAsync("Visitor");

            var roleResult = await _roleManager.CreateAsync(new IdentityRole("Visitor"));

            var user = new User()
                {
                    DisplayName = registerDto.DisplayName,
                    Email = registerDto.Email,
                    PhoneNumber = registerDto.PhoneNumber,
                    UserName = registerDto.Email.Split('@')[0],
                    CountryId = registerDto.CountryId,

                };

            var result = await _userManager.CreateAsync(user , registerDto.Password);

            if (!result.Succeeded)  return BadRequest(new ApiResponse(400 ));

            return Ok(new UserDto(registerDto.DisplayName , registerDto.Email , await _token.CreateToken(user, _userManager)));
        }

        [HttpGet("CheckEmailExists")]
        public async Task<ActionResult<bool>> CheckEmailExists(string Email)
        {
            var userExists = await _userManager.FindByEmailAsync(Email) != null;
            return Ok(!userExists );
        }

        [Authorize]
        [HttpGet("GetCurrentUser")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);

            var user = await _userManager.FindByEmailAsync(Email);

            return Ok(new UserDto(user.DisplayName,user.Email,await _token.CreateToken(user, _userManager)));
        }


      


        //[HttpPost]
        //public async Task<ActionResult> ForgetPaddword()
        //{

        //}
    }
}
