using Blossom.Data.Model;
using System;

namespace Blossom.Data
{
    public interface IStringRepository<TEntity> where TEntity : EntityWithGuidId
    {
        bool Delete(Guid id);
        TEntity GetById(Guid id);
    }
}