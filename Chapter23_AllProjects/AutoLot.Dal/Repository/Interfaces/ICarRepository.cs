using System.Collections.Generic;
using AutoLot.Model.Entities;
using AutoLot.Dal.Repository.Base;

namespace AutoLot.Dal.Repository.Interfaces
{
    public interface ICarRepository : IRepository<Car>
    {
        IEnumerable<Car> FindAllBy(int makeId);
        string GetPetNameById(int id);
    }
}
