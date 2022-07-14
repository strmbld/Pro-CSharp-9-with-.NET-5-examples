using System;
using AutoLot.Dal.Initialization;

namespace AutoLot.Dal.Tests.Base
{
    public sealed class EnsureAutoLotDatabaseTextFixture : IDisposable
    {
        public EnsureAutoLotDatabaseTextFixture()
        {
            var configuration = TestHelper.GetConfiguration();
            var context = TestHelper.GetContext(configuration);
            SampleDataInitializer.ClearAndReseedDatabase(context);
            context.Dispose();
        }


        public void Dispose() { }
    }
}
