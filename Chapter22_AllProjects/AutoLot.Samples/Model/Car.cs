using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Samples.Model
{
    [Table("Inventory", Schema = "dbo")]
    [Index(nameof(MakeId), Name = "IX_Inventory_MakeId")]
    public class Car : BaseEntity
    {
        [Required, StringLength(50)]
        public string Color { get; set; }
        [Required, StringLength(50)]
        public string PetName { get; set; }
        public int MakeId { get; set; }
        [ForeignKey(nameof(MakeId))]
        public Make MakeNavigation { get; set; }
        public Radio RadioNavigation { get; set; }
        [InverseProperty(nameof(Driver.Cars))]
        public IEnumerable<Driver> Drivers { get; set; } = new List<Driver>();
        private bool? _isDrivable;
        public bool IsDrivable
        {
            get => _isDrivable ?? true; // default=true so return true; for default=false return false if null
            set => _isDrivable = value;
        }
    }
}
