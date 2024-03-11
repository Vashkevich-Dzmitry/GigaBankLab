using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GigaBankLab.Models
{
    public class CreditContract : IValidatableObject
    {
        public int Id { get; set; }

        [Display(Name = "Основной счёт")]
        public int CurrentAccountId { get; set; }
        [Display(Name = "Основной счёт")]
        public Account? CurrentAccount { get; set; }

        [Display(Name = "Процентный счёт")]
        public int PercentAccountId { get; set; }
        [Display(Name = "Процентный счёт")]
        public Account? PercentAccount { get; set; }

        [Display(Name = "Клиент")]
        public int ClientId { get; set; }

        [Display(Name = "Клиент")]
        public Client? Client { get; set; }

        [Display(Name = "Кредит")]
        public int CreditProductId { get; set; }
        [Display(Name = "Кредит")]
        public CreditProduct? CreditProduct { get; set; }

        [Display(Name = "Дата открытия")]
        [DataType(DataType.Date)]
        public DateTime OpenDate { get; set; }

        [Display(Name = "Дата закрытия")]
        [DataType(DataType.Date)]
        public DateTime CloseDate { get; set; }

        [Display(Name = "Сумма")]
        public decimal Sum { get; set; }

        [Display(Name = "Закрыт")]
        public bool IsClosed { get; set; }

        [Display(Name = "Кредитная карта")]
        public string CreditCardNumber { get; set; } = default!;

        [Display(Name = "PIN-код")]
        public string CreditCardPIN { get; set; } = default!;

        [NotMapped]
        public IEnumerable<CreditRepayment> Plan { get; set; } = default!;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Sum <= 0)
            {
                yield return new ValidationResult("Сумма должна быть больше нуля", new[] { nameof(Sum) });
            }
        }
    }
}