using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoccerAPI.Data;
using SoccerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApiUser> userManager,  IMapper mapper)
        {
            _userManager = userManager;
           
            _mapper = mapper;
        }

        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var _user = _mapper.Map<ApiUser>(user);
            _user.UserName = user.Email;
            var result = await _userManager.CreateAsync(_user,user.Password);
            await _userManager.AddToRolesAsync(_user, user.Roles);
            return Accepted(result);
        }

        /*[HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Register([FromBody] LoginUser user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password,
                false, false);
            if (!result.Succeeded)
            {
                return Unauthorized(user);
            }
            return Accepted();
           
        }*/
    }
}
