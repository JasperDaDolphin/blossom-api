using System.Linq;

using AutoMapper;

using Blossom.Api.Model.Users;

using Blossom.Service.Model.Users;

namespace Blossom.Mapping
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            // Service -> API
            CreateMap<User, ApplicationUserResource>();
        }
    }
}