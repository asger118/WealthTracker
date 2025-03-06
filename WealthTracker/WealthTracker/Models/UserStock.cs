using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WealthTracker.Models
{
    public class UserStock
    {
        [Key]
        public int UserStockId { get; set; } // Primary Key
        public required User User { get; set; } // Foreign Key
        public required Stock Stock { get; set; } // Foreign Key
        public DateTime PurchaseDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public float PurchasePrice { get; set; }
        public int Quantity { get; set; }
    }
}
