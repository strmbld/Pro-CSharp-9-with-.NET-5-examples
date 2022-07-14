using System.Linq;
using AutoLot.Dal.Repository;
using AutoLot.Dal.Repository.Interfaces;
using AutoLot.Dal.Tests.Base;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace AutoLot.Dal.Tests.IntegrationTests
{
    [Collection("Integration Tests")]
    public class OrderTests : BaseTest, IClassFixture<EnsureAutoLotDatabaseTextFixture>
    {
        private readonly IOrderRepository repository;

        public OrderTests()
        {
            repository = new OrderRepository(context);
        }


        [Fact]
        public void ShouldGetAllViewModels()
        {
            var qs = context.Orders.ToQueryString();

            var orders = context.Orders.ToList();

            Assert.NotEmpty(orders);
            Assert.Equal(4, orders.Count);
        }

        [Theory]
        [InlineData("Black", 2)]
        [InlineData("Rust", 1)]
        [InlineData("Yellow", 1)]
        [InlineData("Green", 0)]
        [InlineData("Pink", 1)]
        [InlineData("Brown", 0)]
        public void ShouldGetAllViewModelsByColor(string color, int expectedCount)
        {
            var query = repository.GetOrdersViewModel().Where(c => c.Color == color);
            var qs = query.ToQueryString();
            var orders = query.ToList();
            Assert.Equal(expectedCount, orders.Count);
        }

        [Fact]
        public void ShouldGetAllOrdersExceptFiltered()
        {
            var query = context.Orders.AsQueryable();
            var qs = query.ToQueryString();
            var orders = query.ToList();
            Assert.NotEmpty(orders);
            Assert.Equal(4, orders.Count);
        }

        public override void Dispose()
        {
            repository.Dispose();
        }
    }
}
