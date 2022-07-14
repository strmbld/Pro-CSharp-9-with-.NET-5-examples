using System;
using System.Data;
using AutoLot.Dal.EfStructures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

namespace AutoLot.Dal.Tests.Base
{
    public abstract class BaseTest : IDisposable
    {
        protected readonly IConfiguration configuration;
        protected readonly ApplicationDbContext context;

        protected BaseTest()
        {
            configuration = TestHelper.GetConfiguration();
            context = TestHelper.GetContext(configuration);
        }


        protected void ExecuteInTransaction(Action action)
        {
            var strategy = context.Database.CreateExecutionStrategy();
            strategy.Execute(() =>
            {
                using var transaction = context.Database.BeginTransaction();
                action();
                transaction.Rollback();
            });
        }

        protected void ExecuteInSharedTransaction(Action<IDbContextTransaction> action)
        {
            var strategy = context.Database.CreateExecutionStrategy();
            strategy.Execute(() =>
            {
                using IDbContextTransaction transaction = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted);
                action(transaction);
                transaction.Rollback();
            });
        }

        public virtual void Dispose() => context.Dispose();
    }
}
