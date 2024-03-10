using System.ComponentModel.DataAnnotations;

namespace GigaBankLab.Models
{
    public class CreditRepayment
    {
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }
        [Display(Name = "Основной долг")]
        public decimal MainDebt { get; set; }
        [Display(Name = "Долг по процентам")]
        public decimal PercentDebt { get; set; }
        [Display(Name = "Суммарный долг")]
        public decimal PaymentSum { get; set; }
    }
}
