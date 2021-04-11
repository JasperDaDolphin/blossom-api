using Blossom.Data.Model.BusinessProfiles;
using Blossom.Data.Model.StudentProfiles;

namespace Blossom.Api.Model.Users
{
    public class ApplicationUserResource
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public StudentProfileEntity StudentProfile { get; set; }

        public BusinessProfileEntity BusinessProfile { get; set; }
    }
}