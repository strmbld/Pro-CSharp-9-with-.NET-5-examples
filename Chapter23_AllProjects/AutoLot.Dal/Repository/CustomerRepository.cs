using System.Collections.Generic;
using System.Linq;
using AutoLot.Dal.EfStructures;
using AutoLot.Model.Entities;
using AutoLot.Dal.Repository.Base;
using AutoLot.Dal.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Dal.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context) { }

        internal CustomerRepository(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public override IEnumerable<Customer> FindAll()
            => Table
            .Include(c => c.Orders)
            .OrderBy(c => c.PersonalInformation.LastName);
    }
}
