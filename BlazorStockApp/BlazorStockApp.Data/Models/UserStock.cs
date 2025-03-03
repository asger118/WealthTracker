
using BlazorStockApp.Shared.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorStockApp.Data.Models
{
    public class UserStock
    {
        [Key]
        public int UserStockId { get; set; } // Primary Key
        public User User { get; set; } // Foreign Key
        public StockMeta StockMeta { get; set; } // Foreign Key

        public DateTime PurchaseDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; }
        public int Quantity { get; set; }
    }
}
