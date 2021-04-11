using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blossom.Api.Model.Users
{
    public class UpdateUserRequest
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }
    }
}