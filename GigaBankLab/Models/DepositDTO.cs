using System.ComponentModel.DataAnnotations;

namespace GigaBankLab.Models
{
    public class DepositDTO
    {

        [Display(Name = "Клиент")]
        public int ClientId { get; set; }

        [Display(Name = "Депозит")]
        public int DepositId { get; set; }
        [Display(Name = "Сумма")]
        public decimal Amount { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Amount <= 0)
            {
                yield return new ValidationResult("Сумма должна быть больше нуля", new[] { nameof(Amount) });
            }
        }
    }
}