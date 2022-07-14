using System.Linq;
using AutoLot.Dal.Repository;
using AutoLot.Dal.Repository.Interfaces;
using AutoLot.Dal.Tests.Base;
using AutoLot.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Xunit;


namespace AutoLot.Dal.Tests.IntegrationTests
{
    [Collection("Integration Tests")]
    public class MakeTests : BaseTest, IClassFixture<EnsureAutoLotDatabaseTextFixture>
    {
        private readonly IMakeRepository repository;

        public MakeTests() => repository = new MakeRepository(context);


        [Fact]
        public void ShouldGetAllMakesAndYellowCars()
        {
            var query = context.Makes
                .IgnoreQueryFilters()
                .Include(m => m.Cars.Where(c => c.Color == "Yellow"));
            var qs = query.ToQueryString();
            var makes = query.ToList();
            Assert.NotNull(makes);
            Assert.NotEmpty(makes);
            Assert.NotEmpty(makes.Where(m => m.Cars.Any()));
            Assert.Empty(makes.First(m => m.Id == 1).Cars);
            Assert.Empty(makes.First(m => m.Id == 2).Cars);
            Assert.Empty(makes.First(m => m.Id == 3).Cars);
            Assert.Single(makes.First(m => m.Id == 4).Cars);
            Assert.Empty(makes.First(m => m.Id == 5).Cars);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 3)]
        [InlineData(6, 1)]
        public void ShouldGetAllCarsForMakeExplicitlyWithQueryFilters(int makeId, int carCount)
        {
            Make m = context.Makes.First(m => m.Id == makeId);
            IQueryable<Car> query = context.Entry(m).Collection(m => m.Cars).Query();
            var qs = query.ToQueryString();
            query.Load();
            Assert.Equal(carCount, m.Cars.Count());
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 3)]
        [InlineData(6, 1)]
        public void ShouldGetAllCarsForMakeExplicitlyWithQueryNoFilters(int makeId, int carCount)
        {
            Make m = context.Makes.First(m => m.Id == makeId);
            IQueryable<Car> query = context.Entry(m).Collection(m => m.Cars).Query().IgnoreQueryFilters();
            var qs = query.IgnoreQueryFilters().ToQueryString();
            query.Load();
            Assert.Equal(carCount, m.Cars.Count());
        }

        public override void Dispose()
        {
            repository.Dispose();
        }
    }
}
