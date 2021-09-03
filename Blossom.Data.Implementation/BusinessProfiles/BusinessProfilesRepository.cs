using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Blossom.Data.Model;
using Blossom.Data.Model.BusinessProfiles;
using Blossom.Data.BusinessProfiles;
using System;
using System.Linq.Expressions;

namespace Blossom.Data.Implementation.BusinessProfiles
{
    public class BusinessProfilesRepository : StringRepositoryBase<BusinessProfileEntity>, IBusinessProfilesRepository
    {
        public BusinessProfilesRepository(BlossomContext context) : base(context) { }

        public override IEnumerable<BusinessProfileEntity> Get(Expression<Func<BusinessProfileEntity, bool>> filter = null)
        {
            var query = _context.Set<BusinessProfileEntity>().Include(u => u.User).AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.AsEnumerable();
        }

        public override BusinessProfileEntity GetById(Guid id)
        {
            return _context.Set<BusinessProfileEntity>()
                .Include(u => u.User)
                .Where(u => u.Id == id)
                .SingleOrDefault();
        }

        public override BusinessProfileEntity Update(BusinessProfileEntity input)
        {
            var entity = this.GetById(input.Id);

            if (entity != null)
            {
                if (input.Location != null)
                {
                    entity.Location = input.Location;
                }

                if (input.Name != null)
                {
                    entity.Name = input.Name;
                }

                if (input.PhoneNumber != null)
                {
                    entity.PhoneNumber = input.PhoneNumber;
                }

                if (input.Size != null)
                {
                    entity.Size = input.Size;
                }

                if (input.Type != null)
                {
                    entity.Type = input.Type;
                }

                if (input.Website != null)
                {
                    entity.Website = input.Website;
                }

                entity.DateUpdated = DateTime.Now;

                _context.SaveChanges();
            }
            else
			{
                throw new ArgumentException("Business Profile not found.");
			}

            return entity;
        }
    }
}