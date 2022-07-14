using System.Collections.Generic;
using System.Linq;
using AutoLot.Dal.Exceptions;
using AutoLot.Dal.Repository;
using AutoLot.Dal.Tests.Base;
using AutoLot.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Xunit;


namespace AutoLot.Dal.Tests.IntegrationTests
{
    [Collection("Integration Tests")]
    public class CarTests : BaseTest, IClassFixture<EnsureAutoLotDatabaseTextFixture>
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 3)]
        [InlineData(6, 1)]
        public void ShouldGetTheCarsByMake(int makeId, int expectedCount)
        {
            IQueryable<Car> query = context.Cars.IgnoreQueryFilters().Where(c => c.MakeId == makeId);
            var qs = query.ToQueryString();
            List<Car> cars = query.ToList();
            Assert.Equal(expectedCount, cars.Count);
        }

        [Fact]
        public void ShouldReturnDrivableWithQueryFilterSet()
        {
            IQueryable<Car> query = context.Cars;
            var qs = query.ToQueryString();
            List<Car> cars = query.ToList();
            Assert.NotEmpty(cars);
            Assert.Equal(9, cars.Count);
        }

        [Fact]
        public void ShouldGetAllCars()
        {
            IQueryable<Car> query = context.Cars.IgnoreQueryFilters();
            var qs = query.ToQueryString();
            List<Car> cars = query.ToList();
            Assert.Equal(10, cars.Count);
        }

        [Fact]
        public void ShouldGetAllCarsWithMakes()
        {
            IIncludableQueryable<Car, Make?> query = context.Cars.Include(c => c.MakeNavigation);
            var qs = query.ToQueryString();
            List<Car> cars = query.ToList();
            Assert.Equal(9, cars.Count);
        }

        [Fact]
        public void ShouldGetCarsOnOrderWithRelatedProperties()
        {
            IIncludableQueryable<Car, Customer?> query = context.Cars
                .Where(c => c.Orders.Any())
                .Include(c => c.MakeNavigation)
                .Include(c => c.Orders).ThenInclude(o => o.CustomerNavigation);
            var qs = query.ToQueryString();
            List<Car> cars = query.ToList();
            Assert.Equal(4, cars.Count);
            cars.ForEach(c =>
            {
                Assert.NotNull(c.MakeNavigation);
                Assert.NotNull(c.Orders.ToList()[0].CustomerNavigation);
            });
        }

        [Fact]
        public void ShouldGetCarsOnOrderWithRelatedPropertiesAsSplitQuery()
        {
            IQueryable<Car> query = context.Cars
                .Where(c => c.Orders.Any())
                .Include(c => c.MakeNavigation)
                .Include(c => c.Orders).ThenInclude(o => o.CustomerNavigation)
                .AsSplitQuery();
            List<Car> cars = query.ToList();
            Assert.Equal(4, cars.Count);
            cars.ForEach(c =>
            {
                Assert.NotNull(c.MakeNavigation);
                Assert.NotNull(c.Orders.ToList()[0].CustomerNavigation);
            });
        }

        [Fact]
        public void ShouldGetReferenceExplicitly()
        {
            Car c = context.Cars.First(c => c.Id == 1);
            Assert.Null(c.MakeNavigation);
            var query = context.Entry(c).Reference(c => c.MakeNavigation).Query();
            var qs = query.ToQueryString();
            query.Load();
            Assert.NotNull(c.MakeNavigation);
        }

        [Fact]
        public void ShouldGetCollectionRelatedExplicitly()
        {
            Car c = context.Cars.First(c => c.Id == 1);
            Assert.Empty(c.Orders);
            var query = context.Entry(c).Collection(c => c.Orders).Query();
            var qs = query.ToQueryString();
            query.Load();
            Assert.Single(c.Orders);
        }

        [Fact]
        public void SelectAllRawSqlWFilters()
        {
            var entity = context.Model.FindEntityType($"{typeof(Car).FullName}");
            var tableName = entity.GetTableName();
            var schemaName = entity.GetSchema();
            List<Car> cars = context.Cars.FromSqlRaw($"SELECT * FROM {schemaName}.{tableName}").ToList();
            Assert.Equal(9, cars.Count);
        }

        [Fact]
        public void SelectAllRawSqlNoFilters()
        {
            var entity = context.Model.FindEntityType($"{typeof(Car).FullName}");
            var tableName = entity.GetTableName();
            var schemaName = entity.GetSchema();
            List<Car> cars = context.Cars.FromSqlRaw($"SELECT * FROM {schemaName}.{tableName}").IgnoreQueryFilters().ToList();
            Assert.Equal(10, cars.Count);
        }

        [Fact]
        public void ShouldGetOneUsingInterpolation()
        {
            var carId = 1;
            Car c = context.Cars
                .FromSqlInterpolated($"SELECT * FROM dbo.Inventory WHERE Id = {carId}")
                .Include(c => c.MakeNavigation)
                .First();
            Assert.Equal("Black", c.Color);
            Assert.Equal("VW", c.MakeNavigation.Name);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 3)]
        [InlineData(6, 1)]
        public void ShouldGetCarsByMakeRawSql(int makeId, int expectedCount)
        {
            var entity = context.Model.FindEntityType($"{typeof(Car).FullName}");
            var tableName = entity.GetTableName();
            var schemaName = entity.GetSchema();
            List<Car> cars = context.Cars.FromSqlRaw($"SELECT * FROM {schemaName}.{tableName}")
                .Where(c => c.MakeId == makeId).ToList();
            Assert.Equal(expectedCount, cars.Count);
        }

        [Fact]
        public void AggregateCountFiltered()
        {
            int count = context.Cars.Count();
            Assert.Equal(9, count);
        }

        [Fact]
        public void AggregateCountNoFilter()
        {
            int count = context.Cars.IgnoreQueryFilters().Count();
            Assert.Equal(10, count);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 3)]
        [InlineData(6, 1)]
        public void CountByMakeInnerWhere(int makeId, int expectedCount)
        {
            int count = context.Cars.Count(c => c.MakeId == makeId);
            Assert.Equal(expectedCount, count);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 3)]
        [InlineData(6, 1)]
        public void CountByMakeWhereBeforeCount(int makeId, int expectedCount)
        {
            int count = context.Cars.Where(c => c.MakeId == makeId).Count();
            Assert.Equal(expectedCount, count);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(11, false)]
        public void CheckForAnyCarsWithMake(int makeId, bool expected)
        {
            bool res = context.Cars.Any(c => c.MakeId == makeId);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(1, false)]
        [InlineData(11, false)]
        public void CheckAllCarsWithSameMake(int makeId, bool expected)
        {
            bool res = context.Cars.All(c => c.MakeId == makeId);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(1, "Zippy")]
        [InlineData(2, "Rusty")]
        [InlineData(3, "Mel")]
        [InlineData(4, "Clunker")]
        [InlineData(5, "Bimmer")]
        [InlineData(6, "Hank")]
        [InlineData(7, "Pinky")]
        [InlineData(8, "Pete")]
        [InlineData(9, "Brownie")]
        public void ShouldGetValFromSP(int id, string expected)
        {
            Assert.Equal(expected, new CarRepository(context).GetPetNameById(id));
        }

        [Fact]
        public void ShouldAddOne()
        {
            ExecuteInTransaction(RunTest);

            void RunTest()
            {
                Car c = new() { Color = "Yellow", MakeId = 1, PetName = "Herbie" };
                int count = context.Cars.Count();
                context.Cars.Add(c);
                context.SaveChanges();
                int newCount = context.Cars.Count();
                Assert.Equal(count + 1, newCount);
            }
        }

        [Fact]
        public void ShouldAddOneWithAttach()
        {
            ExecuteInTransaction(RunTest);

            void RunTest()
            {
                Car c = new() { Color = "Yellow", MakeId = 1, PetName = "Herbie" };
                int count = context.Cars.Count();
                context.Cars.Attach(c);
                Assert.Equal(EntityState.Added, context.Entry(c).State);
                context.SaveChanges();
                int newCount = context.Cars.Count();
                Assert.Equal(count + 1, newCount);
            }
        }

        [Fact]
        public void ShouldAddRange()
        {
            ExecuteInTransaction(Run);

            void Run()
            {
                // mssql adapter requires 4-40 rows to insert to activate batch processing
                List<Car> cars = new()
                {
                    new() { Color = "Yellow", MakeId = 1, PetName = "Herbie" },
                    new() { Color = "White", MakeId = 2, PetName = "Mach 5" },
                    new() { Color = "Pink", MakeId = 3, PetName = "Avon" },
                    new() { Color = "Blue", MakeId = 4, PetName = "Blueberry" },
                };

                int count = context.Cars.Count();
                context.Cars.AddRange(cars);
                context.SaveChanges();
                int newCount = context.Cars.Count();
                Assert.Equal(count + 4, newCount);
            }
        }

        [Fact]
        public void ShouldAddCascade()
        {
            ExecuteInTransaction(Run);

            void Run()
            {
                Make m = new() { Name = "Honda" };
                Car c = new() { Color = "Yellow", MakeId = 1, PetName = "Herbie" };
                ((List<Car>)m.Cars).Add(c);
                context.Makes.Add(m);
                int cCount = context.Cars.Count();
                int mCount = context.Makes.Count();
                context.SaveChanges();
                int newCCount = context.Cars.Count();
                int newMCount = context.Makes.Count();
                Assert.Equal(cCount + 1, newCCount);
                Assert.Equal(mCount + 1, newMCount);
            }
        }

        [Fact]
        public void ShouldUpdateOne()
        {
            ExecuteInSharedTransaction(Run);

            void Run(IDbContextTransaction transaction)
            {
                Car c = context.Cars.First(c => c.Id == 1);
                Assert.Equal("Black", c.Color);

                c.Color = "White";
                // update call not needed
                context.SaveChanges();
                Assert.Equal("White", c.Color);
                var context2 = TestHelper.GetContextFromExisting(context, transaction);
                Car c2 = context2.Cars.First(c => c.Id == 1);
                Assert.Equal("White", c2.Color);
            }
        }

        [Fact]
        public void ShouldUpdateOneLoadedAsNoTracking()
        {
            ExecuteInSharedTransaction(Run);

            void Run(IDbContextTransaction transaction)
            {
                Car c = context.Cars.AsNoTracking().First(c => c.Id == 1);
                Assert.Equal("Black", c.Color);

                Car updated = new()
                {
                    Color="White",
                    Id=c.Id, // when != 0 EF threats entity as existing and query it as update 
                    MakeId=c.MakeId,
                    PetName=c.PetName,
                    TimeStamp=c.TimeStamp,
                    IsDrivable=c.IsDrivable,
                };
                var context2 = TestHelper.GetContextFromExisting(context, transaction);
                // context2.Entry(updated).State = EntityState.Modified
                context2.Cars.Update(updated);
                context2.SaveChanges();
                var context3 = TestHelper.GetContextFromExisting(context, transaction);
                Car c2 = context3.Cars.First(c => c.Id == 1);
                Assert.Equal("White", c2.Color);
            }
        }

        [Fact]
        public void ShouldThrowConcurrency()
        {
            ExecuteInTransaction(Run);

            void Run()
            {
                Car c = context.Cars.First();
                context.Database.ExecuteSqlInterpolated($"UPDATE dbo.Inventory SET Color='Pink' WHERE Id = {c.Id}");
                c.Color = "Yellow";
                var exception = Assert.Throws<CustomConcurrencyException>(() => context.SaveChanges());
                var entry = ((DbUpdateConcurrencyException)exception.InnerException)?.Entries[0];
                PropertyValues origProps = entry.OriginalValues;
                PropertyValues current = entry.CurrentValues;
                PropertyValues fromDB = entry.GetDatabaseValues();
            }
        }

        [Fact]
        public void ShouldRemoveOne()
        {
            ExecuteInTransaction(Run);

            void Run()
            {
                int count = context.Cars.Count();
                Car c = context.Cars.First(c => c.Id == 2);
                context.Cars.Remove(c);
                context.SaveChanges();
                int newCount = context.Cars.Count();
                Assert.Equal(count - 1, newCount);
                Assert.Equal(EntityState.Detached, context.Entry(c).State);
            }
        }

        [Fact]
        public void ShouldRemoveOneLoadedAsNoTracking()
        {
            ExecuteInSharedTransaction(Run);

            void Run(IDbContextTransaction transaction)
            {
                int count = context.Cars.Count();
                Car c = context.Cars.AsNoTracking().First(c => c.Id == 2);
                var context2 = TestHelper.GetContextFromExisting(context, transaction);
                // context2.Entry(c).State = EntityState.Deleted;
                context2.Cars.Remove(c);
                context2.SaveChanges();
                int newCount = context.Cars.Count();
                Assert.Equal(count - 1, newCount);
                Assert.Equal(EntityState.Detached, context.Entry(c).State);
            }
        }

        [Fact]
        public void ShouldFailToRemoveOne()
        {
            ExecuteInTransaction(Run);

            void Run()
            {
                Car c = context.Cars.First(c => c.Id == 1);
                context.Cars.Remove(c);
                Assert.Throws<CustomException>(() => context.SaveChanges());
            }
        }
    }
}
