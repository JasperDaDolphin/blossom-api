using System;
using NUnit.Framework;
using Blossom.Data.Model;
using Blossom.Data.Implementation.Users;
using Blossom.Service.Implementation.Users;
using AutoMapper;
using Blossom.Mapping;
using Blossom.Service.Model.Users;
using System.Data.Common;
using System.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace Blossom.Service.Implementation.Test
{
    [TestFixture]
    public abstract class ServiceFactoryTest
    {
        protected BlossomContext _factory;
        protected IDbContextTransaction _transaction;
        protected IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _factory = new BlossomContextFactory().CreateDbContext();
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<ServiceMappingProfile>();
            });
            _transaction = _factory.Database.BeginTransaction();
            _mapper = new Mapper(config);
        }

        [TearDown]
        public void TearDown()
        {
            _transaction.Rollback();
        }
    }
}