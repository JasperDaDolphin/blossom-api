using System.Linq;

using AutoMapper;
using Blossom.Api.Model.BusinessProfiles;
using Blossom.Api.Model.StudentProfiles;
using Blossom.Api.Model.Users;
using Blossom.Service.Model.BusinessProfiles;
using Blossom.Service.Model.StudentProfiles;
using Blossom.Service.Model.Users;

namespace Blossom.Mapping
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            // Service -> API
            CreateMap<User, ApplicationUserResource>();

            CreateMap<CreateUserRequest, User>();

            CreateMap<UpdateUserRequest, User>();

            //
            CreateMap<BusinessProfile, ApplicationBusinessProfileResource>();

            CreateMap<CreateBusinessProfileRequest, BusinessProfile>();

            CreateMap<UpdateBusinessProfileRequest, BusinessProfile>();


            //
            CreateMap<StudentProfile, ApplicationStudentProfileResource>();

            CreateMap<CreateStudentProfileRequest, StudentProfile>();

            CreateMap<UpdateStudentProfileRequest, StudentProfile>();
        }
    }
}