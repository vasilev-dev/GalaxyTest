using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaxyTest.Contexts;
using GalaxyTest.Models;
using GalaxyTest.Requests;
using GalaxyTest.Responses;
using GalaxyTest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GalaxyTest.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly AppDbContext _dbContext;

        public UserController(IIdentityService identityService, AppDbContext dbContext)
        {
            _identityService = identityService;
            _dbContext = dbContext;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest userLoginRequest)
        {
            var authResult = await _identityService.LoginAsync(userLoginRequest.Username, userLoginRequest.Password);

            if (!authResult.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResult.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResult.Token,
                Username = userLoginRequest.Username
            });
        }

        [Authorize]
        [HttpGet("user/information")]
        public async Task<IActionResult> GetInformation()
        {
            var username = HttpContext.User.Identity.Name;
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username);

            return Ok(user.Information);
        } 
    }
}