using Blossom.Api.Model.BusinessProfiles;
using Blossom.Api.Model.StudentProfiles;
using Blossom.Data.Model.BusinessProfiles;
using Blossom.Data.Model.StudentProfiles;
using System;
using System.Collections.Generic;

namespace Blossom.Api.Model.Users
{
    public class ApplicationUserResource
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string AuthId { get; set; }

        public string Name { get; set; }

        public ICollection<ApplicationStudentProfileResource> StudentProfile { get; set; }

        public ICollection<ApplicationBusinessProfileResource> BusinessProfile { get; set; }
    }
}