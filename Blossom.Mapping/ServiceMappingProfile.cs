using AutoMapper;
using Blossom.Data.Model.BusinessProfiles;
using Blossom.Data.Model.StudentProfiles;
using Blossom.Data.Model.Users;
using Blossom.Service.Model.BusinessProfiles;
using Blossom.Service.Model.StudentProfiles;
using Blossom.Service.Model.Users;

namespace Blossom.Mapping
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            // Two way mappings
            CreateMap<UserEntity, User>().ReverseMap();

            CreateMap<StudentProfileEntity, StudentProfile>().ReverseMap();

            CreateMap<BusinessProfileEntity, BusinessProfile>().ReverseMap();
        }
    }
}