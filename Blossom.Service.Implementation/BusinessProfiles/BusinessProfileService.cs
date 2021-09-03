using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Blossom.Data.BusinessProfiles;
using Blossom.Data.Model.BusinessProfiles;
using Blossom.Data.Model.Users;
using Blossom.Data.Users;
using Blossom.Service.BusinessProfiles;
using Blossom.Service.Model.BusinessProfiles;

namespace Blossom.Service.Implementation.BusinessProfiles
{
    public class BusinessProfileService : IBusinessProfileService
    {
        private readonly IMapper _mapper;
        private readonly IBusinessProfilesRepository _businessProfileRepository;
        private readonly IUserRepository _userRepository;

        public BusinessProfileService(
            IMapper mapper,
            IBusinessProfilesRepository businessProfileRepository,
            IUserRepository userRepository
        )
        {
            _mapper = mapper;
            _businessProfileRepository = businessProfileRepository;
            _userRepository = userRepository;
        }

        public BusinessProfile CreateBusinessProfile(BusinessProfile profile)
        {
            var user = _userRepository.GetById(profile.UserId);
            if (user != null)
			{
                if (user.BusinessProfile.Count <= 0)
				{
                    var businessProfileEntity = new BusinessProfileEntity
                    {
                        Name = profile.Name,
                        Location = profile.Location,
                        PhoneNumber = profile.PhoneNumber,
                        Type = profile.Type,
                        Size = profile.Size,
                        Website = profile.Website,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        User = user
                    };

                    var result = _businessProfileRepository.Insert(businessProfileEntity);

                    return _mapper.Map<BusinessProfile>(result);
                } 
                else
				{
                    throw new ArgumentException("User already has BusinessProfile.");
				}
            }
            else
            {
                throw new ArgumentException("User does not exist.");
            }
        }

        public void DeleteBusinessProfile(Guid id)
        {
            _businessProfileRepository.Delete(id);
        }

        public List<BusinessProfile> GetAll(Expression<Func<BusinessProfileEntity, bool>> filter = null)
        {
            var userEntities = _businessProfileRepository.Get(filter);
            return _mapper.Map<List<BusinessProfile>>(userEntities);
        }

        public BusinessProfile GetById(Guid id)
        {
            var userEntity = _businessProfileRepository.GetById(id);
            return _mapper.Map<BusinessProfile>(userEntity);
        }

        public BusinessProfile UpdateBusinessProfile(BusinessProfile profile)
        {
            var profileEntity = _mapper.Map<BusinessProfileEntity>(profile);
            return _mapper.Map<BusinessProfile>(_businessProfileRepository.Update(profileEntity));
        }
    }
}
