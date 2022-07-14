using System.Collections.Generic;
using System.Linq;
using AutoLot.Model.Entities;
using AutoLot.Dal.Repository.Base;
using AutoLot.Model.ViewModel;

namespace AutoLot.Dal.Repository.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        IQueryable<CustomerOrderViewModel> GetOrdersViewModel();
    }
}
