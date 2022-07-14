using AutoLot.Model.Entities;
using AutoLot.Dal.Repository.Base;
using AutoLot.Dal.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoLot.Dal.EfStructures;
using System.Linq;
using AutoLot.Model.ViewModel;

namespace AutoLot.Dal.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context) { }

        internal OrderRepository(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public IQueryable<CustomerOrderViewModel> GetOrdersViewModel()
            => Context.CustomerOrderViewModels!.AsQueryable();
    }
}
