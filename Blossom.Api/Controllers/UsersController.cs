using System.Collections.Generic;

using AutoMapper;

using Blossom.Data.Implementation;
using Microsoft.AspNetCore.Mvc;
using Blossom.Api.Model.Users;
using Blossom.Service.Model.Users;
using Blossom.Service.Users;
using System;
using Blossom.Data.Model.Users;
using System.Linq.Expressions;
using Flee.PublicTypes;
using System.Reflection;
using System.Linq;
using System.Text.Json;
using Blossom.Data;
using Newtonsoft.Json;
using Blossom.Api.Model.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Blossom.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize]
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
        [Authorize(Policies.DeleteUser)]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }

        [HttpGet]
        [Authorize(Policies.ReadUserAll)]
        public IActionResult GetAll([FromQuery(Name = "query")] string? filters = "")
        {
            var expressionFilters = PredicateBuilder.CreateExpressions<UserEntity>(filters);
            return Ok(_mapper.Map<List<ApplicationUserResource>>(_userService.GetAll(expressionFilters)));
        }

        [HttpPost]
        [Authorize(Policies.CreateUser)]
        public IActionResult CreateUser([FromBody] CreateUserRequest request)
        {
            var user = _mapper.Map<User>(request);
            return Ok(_userService.CreateUser(user));
        }

		[HttpGet("{id}")]
        [Authorize(Policies.ReadUser)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var user = _userService.GetById(id);
            return Ok(_mapper.Map<ApplicationUserResource>(user));
        }

        [HttpPut("{id}")]
        [Authorize(Policies.UpdateUser)]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequest request)
        {
            var user = _mapper.Map<User>(request);
            user.Id = id;
            return Ok(_mapper.Map<ApplicationUserResource>(_userService.UpdateUser(user)));
        }
    }
}