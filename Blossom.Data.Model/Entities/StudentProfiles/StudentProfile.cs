using Blossom.Data.Model.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blossom.Data.Model.StudentProfiles
{
    public class StudentProfileEntity : EntityWithGuidId
    {
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

        [DataType(DataType.DateTime)]
        [Column(TypeName = "DateTime")]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        [Column(TypeName = "DateTime")]
        public DateTime DateUpdated { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
    }
}