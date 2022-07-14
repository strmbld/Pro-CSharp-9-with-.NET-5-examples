using AutoLot.Dal.EfStructures;
using AutoLot.Dal.Repository.Base;
using AutoLot.Dal.Repository.Interfaces;
using AutoLot.Model.Entities;
using Microsoft.EntityFrameworkCore;


namespace AutoLot.Dal.Repository
{
    public class CreditRiskRepository : BaseRepository<CreditRisk>, ICreditRiskRepository
    {
        public CreditRiskRepository(ApplicationDbContext context) : base(context) { }

        internal CreditRiskRepository(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
