using System.Collections.Generic;

using Blossom.Data.Model.BusinessProfiles;
using Blossom.Data.Model.StudentProfiles;

namespace Blossom.Data.Model.Users
{
    public class UserEntity : EntityWithGuidId
    {
        public string AuthId { get; set; }
         
        public string Email { get; set; }

        public string Name { get; set; }

        public StudentProfileEntity StudentProfile { get; set; }

        public BusinessProfileEntity BusinessProfile { get; set; }
    }
}