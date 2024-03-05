using System.ComponentModel.DataAnnotations;

namespace GigaBankLab.Models
{
    public class DepositDTO
    {
        [Required]
        public int ClientId { get; set; }

        [Required]
        public int DepositId { get; set; }
        [Required]
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