using System.Collections.Generic;

using Blossom.Data.Model.Users;

namespace Blossom.Data.Users
{
    public interface IUserRepository : IRepository<UserEntity>, IStringRepository<UserEntity>
    {
        UserEntity GetByAuthId(string authId);
    }
}