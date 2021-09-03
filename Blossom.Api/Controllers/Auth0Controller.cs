using AutoMapper;
using Blossom.Api.Model.Authentication;
using Blossom.Api.Model.Users;
using Blossom.Service.Model.Users;
using Blossom.Service.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blossom.Api.Controllers
{
	[ApiController]
    [Route("api/auth0")]
    public class Auth0Controller : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public Auth0Controller(
            IMapper mapper,
            IUserService userService,
            IConfiguration configuration
        )
        {
            _mapper = mapper;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest request)
        {
            if (RequestHasValidApiKey())
            {
                var user = _mapper.Map<User>(request);
                return Ok(_userService.CreateUser(user));
            }
            return Forbid();
        }

        [HttpGet]
        public IActionResult GetCurrentUser()
        {
            var user = _userService.GetByAuthId(HttpContext.User.Identity.Name);
            return Ok(_mapper.Map<ApplicationUserResource>(user));
        }


        public bool RequestHasValidApiKey()
        {
            var auth0BlossomKey = _configuration.GetValue(typeof(string), "Auth0:BlossomKey");
            return HttpContext.Request.Headers.TryGetValue("BlossomKey", out StringValues value) && value == auth0BlossomKey;
        }
    }
}
