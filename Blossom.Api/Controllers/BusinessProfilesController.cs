using System.Collections.Generic;

using AutoMapper;

using Blossom.Data.Implementation;
using Microsoft.AspNetCore.Mvc;
using Blossom.Api.Model.Users;
using System;
using Blossom.Api.Model.BusinessProfiles;
using Blossom.Service.BusinessProfiles;
using Blossom.Data.Model.BusinessProfiles;
using Blossom.Service.Model.BusinessProfiles;
using Microsoft.AspNetCore.Authorization;
using Blossom.Api.Model.Authentication;

namespace Blossom.Api.Controllers
{
    [ApiController]
    [Route("api/business")]
    [Authorize]
    public class BusinessProfilesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBusinessProfileService _businessService;

        public BusinessProfilesController(
            IMapper mapper,
            IBusinessProfileService businessService
        )
        {
            _mapper = mapper;
            _businessService = businessService;
        }

        [HttpDelete("{id}")]
        [Authorize(Policies.DeleteBusiness)]
        public IActionResult DeleteBusinessProfile([FromRoute] Guid id)
        {
            _businessService.DeleteBusinessProfile(id);
            return NoContent();
        }

        [HttpGet]
        [Authorize(Policies.ReadBusinessAll)]
        public IActionResult GetAll([FromQuery(Name = "query")] string? filters = "")
        {
            var expressionFilters = PredicateBuilder.CreateExpressions<BusinessProfileEntity>(filters);
            var entities = _businessService.GetAll(expressionFilters);
            return Ok(_mapper.Map<List<ApplicationBusinessProfileResource>>(entities));
        }

        [HttpPost]
        [Authorize(Policies.CreateBusiness)]
        public IActionResult CreateBusinessProfile([FromBody] CreateBusinessProfileRequest request)
        {
            var profile = _mapper.Map<BusinessProfile>(request);
            return Ok(_businessService.CreateBusinessProfile(profile));
        }

        [HttpGet("{id}")]
		[Authorize(Policies.ReadBusiness)]
		public IActionResult GetById([FromRoute] Guid id)
        {
            var entities = _businessService.GetById(id);
            return Ok(_mapper.Map<ApplicationBusinessProfileResource>(entities));
        }

        [HttpPut("{id}")]
        [Authorize(Policies.UpdateBusiness)]
        public IActionResult UpdateBusinessProfile([FromRoute] Guid id, [FromBody] UpdateBusinessProfileRequest request)
        {
            var profile = _mapper.Map<BusinessProfile>(request);
            profile.Id = id;
            return Ok(_mapper.Map<ApplicationBusinessProfileResource>(_businessService.UpdateBusinessProfile(profile)));
        }
    }
}