using System.Collections.Generic;
using System.Linq;
using AutoLot.Dal.EfStructures;
using AutoLot.Model.Entities;
using AutoLot.Dal.Repository.Base;
using AutoLot.Dal.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Dal.Repository
{
    public class MakeRepository : BaseRepository<Make>, IMakeRepository
    {
        public MakeRepository(ApplicationDbContext context) : base(context) { }

        internal MakeRepository(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public override IEnumerable<Make> FindAll()
            => Table.OrderBy(m => m.Name);

        public override IEnumerable<Make> FindAllIgnoreQueryFilters()
            => Table.IgnoreQueryFilters().OrderBy(m => m.Name);
    }
}
