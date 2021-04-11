using System.Collections.Generic;

using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Blossom.Api.Model.Users;
using Blossom.Service.Model.Users;
using Blossom.Service.Users;
using System;

namespace Blossom.Api.Controllers
{
    //[Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(
            IMapper mapper, 
            IUserService userService
        )
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<List<ApplicationUserResource>>(_userService.GetAll()));
        }

        [HttpGet("{id}")]
        [Authorize("view:profile")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var user = _userService.GetById(id);
            return Ok(_mapper.Map<ApplicationUserResource>(user));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequest request)
        {
            var user = _mapper.Map<User>(request);
            user.Id = id;
            return Ok(_mapper.Map<ApplicationUserResource>(_userService.UpdateUser(user)));
        }
    }
}