using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Blossom.Data.Model.Users;
using Blossom.Service.Model.Users;

namespace Blossom.Service.Users
{
    public interface IUserService
    {
        User CreateUser(User user);
        void DeleteUser(Guid id);
        List<User> GetAll(Expression<Func<UserEntity, bool>> filter = null);
        User GetById(Guid id);
        User GetByAuthId(string authId);
        User UpdateUser(User user);
    }
}