using System;
using System.Linq;

using Blossom.Data.Model;

namespace Blossom.Data.Implementation
{
    public abstract class StringRepositoryBase<TEntity> : RepositoryBase<TEntity>, IStringRepository<TEntity>
        where TEntity : EntityWithGuidId
    {
        public StringRepositoryBase(BlossomContext context) : base(context) {}

        public virtual bool Delete(Guid id)
        {
            var entity = _context.Set<TEntity>().SingleOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
                return true;
			}
            return false;
        }

        public virtual TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().SingleOrDefault(x => x.Id == id);
        }
    }
}