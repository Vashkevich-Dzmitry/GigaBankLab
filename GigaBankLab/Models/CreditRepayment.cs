namespace GigaBankLab.Models
{
    public class CreditRepayment
    {
        public int RowNumber { get; set; }
        public DateTime Date { get; set; }

        public decimal MainDebt { get; set; }
        public decimal PercentDebt { get; set; }
        public decimal PaymentSum { get; set; }
    }
}
