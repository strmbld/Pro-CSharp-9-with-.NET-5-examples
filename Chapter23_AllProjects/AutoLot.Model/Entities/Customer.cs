using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using AutoLot.Model.Entities.Base;
using AutoLot.Model.Entities.Owned;


namespace AutoLot.Model.Entities
{
    [Table("Customers", Schema = "dbo")]
    public partial class Customer : BaseEntity
    {
        public Person PersonalInformation { get; set; } = new();

        [JsonIgnore]
        [InverseProperty(nameof(CreditRisk.CustomerNavigation))]
        public IEnumerable<CreditRisk> CreditRisks { get; set; } = new List<CreditRisk>();

        [JsonIgnore]
        [InverseProperty(nameof(Order.CustomerNavigation))]
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
