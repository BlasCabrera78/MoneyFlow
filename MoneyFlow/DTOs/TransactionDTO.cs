using MoneyFlow.Entities;

namespace MoneyFlow.DTOs
{
    public class TransactionDTO
    {
       
        public int ServiceId { get; set; }
        public int UserId { get; set; }
        public String Comment { get; set; }
        public DateOnly Date { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
