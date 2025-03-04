using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorStockApp.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DefaultValue("user")]
        public string Role { get; set; }
        
        public float CashBalance { get; set; }

        List<UserStock> UserStocks { get; set; }

        public float TotalAccountValue()
        {
            float total = CashBalance;
            foreach (UserStock stock in UserStocks)
            {
                total += stock.Stock.CurrentPrice * stock.Quantity;
            }
            return total;
        }

        public float TotalInvested()
        {
            float total = 0;
            foreach (UserStock stock in UserStocks)
            {
                total += stock.PurchasePrice * stock.Quantity;
            }
            return total;
        }

        public float TotalProfit()
        {
            float total = 0;
            foreach (UserStock stock in UserStocks)
            {
                total += (stock.Stock.CurrentPrice - stock.PurchasePrice) * stock.Quantity;
            }
            return total;
        }
        public float TotalProfitPercent()
        {
            float invested = TotalInvested();
            if (invested == 0) return 0; // Avoid division by zero
            return (TotalProfit() / invested) * 100;
        }

        public float DayProfit()
        {
            float total = 0;
            foreach (UserStock stock in UserStocks)
            {
                total += (stock.Stock.CurrentPrice - stock.Stock.PreviousClose) * stock.Quantity;
            }
            return total;
        }

        public float DayProfitPercent()
        {
            float totalValue = TotalAccountValue();
            if (totalValue == 0) return 0; // Avoid division by zero
            return (DayProfit() / totalValue) * 100;
        }
    }
}
