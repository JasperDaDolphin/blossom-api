using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blossom.Api.Model.Contact
{
	public class SendContactRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Body is required")]
        public string Body { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
