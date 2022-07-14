using System.Collections.Generic;
using System;
using System.Linq;
using System.Linq.Expressions;
using AutoLot.Dal.Tests.Base;
using AutoLot.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace AutoLot.Dal.Tests.IntegrationTests
{
    [Collection("Integration Tests")]
    public class CustomerTests : BaseTest, IClassFixture<EnsureAutoLotDatabaseTextFixture>
    {
        [Fact]
        public void ShouldGetAllCustomers()
        {
            var qs = context.Customers.ToQueryString();

            var customers = context.Customers.ToList();
            Assert.Equal(5, customers.Count);
        }

        [Fact]
        public void ShouldGetCustomersWithLastNameW()
        {
            IQueryable<Customer> query = context.Customers.Where(c => c.PersonalInformation.LastName.StartsWith("W"));
            var qs = query.ToQueryString();
            List<Customer> customers = query.ToList();
            Assert.Equal(2, customers.Count);
        }

        [Fact]
        public void ShouldGetCustomerWithLastNameWAndFirstNameM()
        {
            IQueryable<Customer> query = context.Customers
                .Where(c => c.PersonalInformation.LastName.StartsWith("W"))
                .Where(c => c.PersonalInformation.FirstName.StartsWith("M"));
            var qs = query.ToQueryString();
            List<Customer> customers = query.ToList();
            Assert.Single(customers);
        }

        [Fact]
        public void ShouldGetCustomerWithLastNameWAndFirstNameM2()
        {
            IQueryable<Customer> query = context.Customers
                .Where(c => c.PersonalInformation.LastName.StartsWith("W")
                && c.PersonalInformation.FirstName.StartsWith("M"));

            var qs = query.ToQueryString();
            List<Customer> customers = query.ToList();
            Assert.Single(customers);
        }

        [Fact]
        public void ShouldGetCustomersWithLastNameWOrH()
        {
            IQueryable<Customer> query = context.Customers
                .Where(c => c.PersonalInformation.LastName.StartsWith("W")
                || c.PersonalInformation.FirstName.StartsWith("H"));

            var qs = query.ToQueryString();
            List<Customer> customers = query.ToList();
            Assert.Equal(2, customers.Count);
        }

        [Fact]
        public void ShouldGetCustomersWithLastNameWOrH2()
        {
            IQueryable<Customer> query = context.Customers
                .Where(c => EF.Functions.Like(c.PersonalInformation.LastName, "W%")
                || EF.Functions.Like(c.PersonalInformation.LastName, "H%"));

            var qs = query.ToQueryString();
            List<Customer> customers = query.ToList();
            Assert.Equal(3, customers.Count);
        }

        [Fact]
        public void ShouldSortByLastNameThenFirstName()
        {
            var query = context.Customers
                .OrderBy(c => c.PersonalInformation.LastName)
                .ThenBy(c => c.PersonalInformation.FirstName);
            var qs = query.ToQueryString();
            List<Customer> customers = query.ToList();
            if (customers.Count <= 1) return;

            for (int i = 0; i < customers.Count - 1; i++)
            {
                var pi = customers[i].PersonalInformation;
                var pi2 = customers[i + 1].PersonalInformation;
                int compareLastName = string.Compare(pi.LastName, pi2.LastName, StringComparison.CurrentCultureIgnoreCase);

                Assert.True(compareLastName <= 0);

                if (compareLastName != 0) continue;

                int compareFirstName = string.Compare(pi.FirstName, pi2.FirstName, StringComparison.CurrentCultureIgnoreCase);
                Assert.True(compareFirstName <= 0);
            }
        }

        [Fact]
        public void ShouldSortByFNThenLNUsingReverse()
        {
            var query = context.Customers
                .OrderBy(c => c.PersonalInformation.LastName)
                .ThenBy(c => c.PersonalInformation.FirstName)
                .Reverse();

            var qs = query.ToQueryString();

            List<Customer> customers = query.ToList();

            if (customers.Count <= 1) return;

            for (int i = 0; i < customers.Count - 1; i++)
            {
                var pi1 = customers[i].PersonalInformation;
                var pi2 = customers[i + 1].PersonalInformation;
                int compareLastName = string.Compare(pi1.LastName, pi2.LastName, StringComparison.CurrentCultureIgnoreCase);
                Assert.True(compareLastName >= 0);
                if (compareLastName != 0) continue;

                int compareFirstName = string.Compare(pi1.FirstName, pi2.FirstName, StringComparison.CurrentCultureIgnoreCase);
                Assert.True(compareFirstName >= 0);
            }
        }

        [Fact]
        public void GetFirstDatabaseOrder()
        {
            Customer c = context.Customers.First();
            Assert.Equal(1, c.Id);
        }

        [Fact]
        public void GetFirstNameOrder()
        {
            Customer c = context.Customers
                .OrderBy(c => c.PersonalInformation.LastName)
                .ThenBy(c => c.PersonalInformation.FirstName)
                .First();
            Assert.Equal(1, c.Id);
        }

        [Fact]
        public void FirstShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => context.Customers.First(c => c.Id == 10));
        }

        [Fact]
        public void FirstOrDefaultShouldReturnDefault()
        {
            // Expression<Func<Customer, bool>> expression = c => c.Id == 10;
            // Customer c = context.Customers.FirstOrDefault(expression);
            Customer c = context.Customers.FirstOrDefault(c => c.Id == 10);
            Assert.Null(c);
        }

        [Fact]
        public void GetLastNameOrder()
        {
            Customer c = context.Customers
                .OrderBy(c => c.PersonalInformation.LastName)
                .ThenBy(c => c.PersonalInformation.FirstName)
                .Last();
            Assert.Equal(4, c.Id);
        }

        [Fact]
        public void GetSingle() // single() returns TOP(2) instead of first() TOP(1) and checks those top(2) for equality and throws if true or no match
        {
            Customer c = context.Customers.Single(c => c.Id == 1);
            Assert.Equal(1, c.Id);
        }

        [Fact]
        public void GetSingleShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => context.Customers.Single(c => c.Id == 10));
        }

        [Fact]
        public void GetSingleShouldThrowUniqueViolation()
        {
            Assert.Throws<InvalidOperationException>(() => context.Customers.Single());
        }

        [Fact]
        public void GetSingleOrDefaultShouldThrowUniqueViolation()
        {
            Assert.Throws<InvalidOperationException>(() => context.Customers.SingleOrDefault());
        }

        [Fact]
        public void GetSingleOrDefaultShouldReturnDefault()
        {
            Customer c = context.Customers.SingleOrDefault(c => c.Id == 10);
            Assert.Null(c);
        }
    }
}
