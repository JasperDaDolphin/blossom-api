using Blossom.Data.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blossom.Api.Model.StudentProfiles
{
	public class CreateStudentProfileRequest
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        //Not Required
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "University is required")]
        public string University { get; set; }

        [Required(ErrorMessage = "Degree is required")]
        public string Degree { get; set; }

        [Required(ErrorMessage = "Majors is required")]
        public string Majors { get; set; }

        [Required(ErrorMessage = "StartingYear is required")]
        public string StartingYear { get; set; }

        [Required(ErrorMessage = "GraduationYear is required")]
        public string GraduationYear { get; set; }

        [Required(ErrorMessage = "WorkingStatus is required")]
        public string WorkingStatus { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Skills are required")]
        public string Skills { get; set; }

        //Not Required
        public string About { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        public Guid UserId { get; set; }
    }
}