using Blossom.Data.Model.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blossom.Data.Model.BusinessProfiles
{
    public class BusinessProfileEntity : EntityWithGuidId
    {
        public string Name { get; set; }

        public string Website { get; set; }

        public string Size { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }

        public string PhoneNumber { get; set; }

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