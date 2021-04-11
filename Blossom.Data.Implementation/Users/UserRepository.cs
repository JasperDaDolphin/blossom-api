using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Blossom.Data.Model;
using Blossom.Data.Model.Users;
using Blossom.Data.Users;
using System;
using System.Linq.Expressions;

namespace Blossom.Data.Implementation.Users
{
    public class UserRepository : StringRepositoryBase<UserEntity>, IUserRepository
    {
        public UserRepository(BlossomContext context) : base(context) { }

        public override IEnumerable<UserEntity> Get(Expression<Func<UserEntity, bool>> filter = null)
        {
            var query = _context.Set<UserEntity>()
                .Include(u => u.StudentProfile)
                .Include(u => u.BusinessProfile)
                .AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.AsEnumerable();
        }

        public override UserEntity GetById(Guid id)
        {
            return _context.Set<UserEntity>()
                .Include(u => u.StudentProfile)
                .Include(u => u.BusinessProfile)
                .Where(u => u.Id == id)
                .SingleOrDefault();
        }

        public UserEntity GetByAuthId(string authId)
        {
            var entity = _context.Set<UserEntity>()
                .Include(u => u.StudentProfile)
                .Include(u => u.BusinessProfile)
                .Where(u => u.AuthId.ToLower() == authId.ToLower())
                .SingleOrDefault();

            return entity;
        }

        public override UserEntity Update(UserEntity inputUser)
        {
            var userEntity = _context.Set<UserEntity>()
                .Single(u => u.Id == inputUser.Id);

            userEntity.Name = inputUser.Name;
            userEntity.Email = inputUser.Email;

            _context.SaveChanges();
            return userEntity;
        }
    }
}