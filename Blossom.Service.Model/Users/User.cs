using Blossom.Service.Model.BusinessProfiles;
using Blossom.Service.Model.StudentProfiles;
using System;

namespace Blossom.Service.Model.Users
{
    public class User: ModelWithGuidId
    {
        public string AuthId { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public StudentProfile StudentProfile { get; set; }

        public BusinessProfile BusinessProfile { get; set; }
    }
}