using Blossom.Data.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blossom.Api.Model.StudentProfiles
{
	public class ApplicationStudentProfileResource
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string University { get; set; }

        public string StartingYear { get; set; }

        public string GraduationYear { get; set; }

        public string Degree { get; set; }

        public string Majors { get; set; }

        public string WorkingStatus { get; set; }

        public string State { get; set; }

        public string Skills { get; set; }

        public string About { get; set; }

        public string UserId { get; set; }
    }
}
