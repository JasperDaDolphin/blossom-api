using System.Collections.Generic;

using AutoMapper;

using Blossom.Data.Implementation;
using Microsoft.AspNetCore.Mvc;
using Blossom.Api.Model.Users;
using System;
using Blossom.Api.Model.StudentProfiles;
using Blossom.Service.StudentProfiles;
using Blossom.Data.Model.StudentProfiles;
using Blossom.Service.Model.StudentProfiles;
using Microsoft.AspNetCore.Authorization;
using Blossom.Api.Model.Authentication;

namespace Blossom.Api.Controllers
{
    [ApiController]
    [Route("api/student")]
    [Authorize]
    public class StudentProfilesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStudentProfileService _studentService;

        public StudentProfilesController(
            IMapper mapper,
            IStudentProfileService studentService
        )
        {
            _mapper = mapper;
            _studentService = studentService;
        }

        [HttpDelete("{id}")]
        [Authorize(Policies.DeleteStudent)]
        public IActionResult DeleteStudentProfile([FromRoute] Guid id)
        {
            _studentService.DeleteStudentProfile(id);
            return NoContent();
        }

        [HttpGet]
        [Authorize(Policies.ReadStudentAll)]
        public IActionResult GetAll([FromQuery(Name = "query")] string? filters = "")
        {
            var expressionFilters = PredicateBuilder.CreateExpressions<StudentProfileEntity>(filters);
            var entities = _studentService.GetAll(expressionFilters);
            return Ok(_mapper.Map<List<ApplicationStudentProfileResource>>(entities));
        }

        [HttpPost]
        [Authorize(Policies.CreateStudent)]
        public IActionResult CreateStudentProfile([FromBody] CreateStudentProfileRequest request)
        {
            var profile = _mapper.Map<StudentProfile>(request);
            return Ok(_studentService.CreateStudentProfile(profile));
        }

        [HttpGet("{id}")]
        [Authorize(Policies.ReadStudent)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entities = _studentService.GetById(id);
            return Ok(_mapper.Map<ApplicationStudentProfileResource>(entities));
        }

        [HttpPut("{id}")]
        [Authorize(Policies.UpdateStudent)]
        public IActionResult UpdateStudentProfile([FromRoute] Guid id, [FromBody] UpdateStudentProfileRequest request)
        {
            var profile = _mapper.Map<StudentProfile>(request);
            profile.Id = id;
            return Ok(_mapper.Map<ApplicationStudentProfileResource>(_studentService.UpdateStudentProfile(profile)));
        }
    }
}