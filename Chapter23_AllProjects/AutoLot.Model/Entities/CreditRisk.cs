using System.ComponentModel.DataAnnotations.Schema;
using AutoLot.Model.Entities.Base;
using AutoLot.Model.Entities.Owned;


namespace AutoLot.Model.Entities
{
    [Table("CreditRisks", Schema = "dbo")]
    public partial class CreditRisk : BaseEntity
    {
        public Person PersonalInformation { get; set; } = new();

        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customer.CreditRisks))]
        public Customer? CustomerNavigation { get; set; }
    }
}
