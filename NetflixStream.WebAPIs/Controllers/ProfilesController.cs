using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetflixStream.Application.DTOs.Users;
using NetflixStream.Domain.UserIdentity;
using NetflixStream.Persistence.Errors;
using NetflixStream.WebAPIs.Extensions;
using System.Security.Claims;

namespace NetflixStream.WebAPIs.Controllers
{
    [Authorize]
    public class ProfilesController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public ProfilesController(UserManager<User> userManager , IMapper mapper )
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("AddAddress")]
        public async Task<ActionResult<AddressDto>> AddAddress(AddressDto addressDto)
        {
            var address = _mapper.Map<AddressDto, Address>(addressDto);

            var email = User.FindFirstValue(ClaimTypes.Email);
            if (email == null) 
                return Unauthorized(new ApiResponse(401, "User not found"));

            var appUser = await _userManager.FindByEmailAsync(email);
            if (appUser == null)
                return NotFound(new ApiResponse(404, "User not found"));

            appUser.Address = address;

            appUser.Address.UserId = appUser.Id;  
         
            var result = await _userManager.UpdateAsync(appUser);
            if (!result.Succeeded) 
                return BadRequest(new ApiResponse(400, "An error occurred while adding user address"));

            return Ok(_mapper.Map<Address, AddressDto>(address));
        }

        [HttpPost("{userId}/addresses")]
        public async Task<ActionResult> AddAddress()
        {
            return Ok("Address added successfully");
        }

        [HttpGet("{userId}/addresses/{addressId}")]
        public async Task<IActionResult> GetAddress(Guid userId, Guid addressId)
        {
            //    var address = await _addressService.GetAddressById(userId, addressId);

            //    if (address == null) return NotFound("Address not found");

            return Ok();
        }
        [HttpPut("{userId}/addresses/{addressId}")]
        public async Task<IActionResult> UpdateAddress()
        {
            return Ok();
        }
        [HttpDelete("{userId}/addresses/{addressId}")]
        public async Task<IActionResult> DeleteAddress()
        {
            return Ok();
        }


        //[HttpPut("GetProfile")]
        //public async Task<ActionResult<AddressDto>> GetProfile(add)
        //{

        //}
        // var AppUser = await _userManager.FindUserWithAddressExtension(User);
    }
}
