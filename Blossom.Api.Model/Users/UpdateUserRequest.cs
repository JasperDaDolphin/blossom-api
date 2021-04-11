using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blossom.Api.Model.Users
{
    public class UpdateUserRequest
    {
        public int? Id { get; set; }
        
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string Username { get; set; }
    }
}