using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Blossom.Data.Implementation;
using Blossom.Data.Model.Users;
using Blossom.Data.Users;
using Blossom.Service.Model.Users;
using Blossom.Service.Users;

namespace Blossom.Service.Implementation.Users
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(
            IMapper mapper,
            IUserRepository userRepository
        )
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public User CreateUser(User user)
        {
            var userEntity = new UserEntity
            {
                AuthId = user.AuthId,
                Name = user.Name,
                Email = user.Email,
            };

            var result = _userRepository.Insert(userEntity);
            return _mapper.Map<User>(result);
        }

        public void DeleteUser(Guid id)
        {
            _userRepository.Delete(id);
        }

        public List<User> GetAll(Expression<Func<UserEntity, bool>> filter = null)
        {
            var userEntities = _userRepository.Get(filter);
            return _mapper.Map<List<User>>(userEntities);
        }

        public User GetById(Guid id)
        {
            var userEntity = _userRepository.GetById(id);
            return _mapper.Map<User>(userEntity);
        }

        public User GetByAuthId(string authId)
        {
            var userEntity = _userRepository.Get(x => x.AuthId == authId).SingleOrDefault();
            return _mapper.Map<User>(userEntity);
        }

        public User UpdateUser(User user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);
            return _mapper.Map<User>(_userRepository.Update(userEntity));
        }
    }
}