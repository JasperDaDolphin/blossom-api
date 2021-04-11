using System;
using System.Collections.Generic;

using Blossom.Service.Model.Users;

namespace Blossom.Service.Users
{
    public interface IUserService
    {
        User CreateUser(User user);
        void DeleteUser(Guid id);
        List<User> GetAll();
        User GetById(Guid id);
        User GetByAuthId(string authId);
        User UpdateUser(User user);
    }
}