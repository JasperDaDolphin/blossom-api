using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blossom.Api.Model.Users
{
    public class CreateUserRequest
    {
        [Required(ErrorMessage = "AuthId is required")]
        public string AuthId { get; set; }

        public string Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }
}