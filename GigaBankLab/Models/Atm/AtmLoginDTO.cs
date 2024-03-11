using System.ComponentModel.DataAnnotations;

namespace GigaBankLab.Models.Atm
{
    public class AtmLoginDTO
    {
        [Display(Name = "Кредитная карта")]
        [RegularExpression(@"\d{16}", ErrorMessage = "Введите номер карты в корректном формате")]
        [Required(ErrorMessage = "Введите номер карты")]
        public string CreditCardNumber { get; set; } = default!;

        [Display(Name = "PIN-код")]
        [RegularExpression(@"\d{4}", ErrorMessage = "Введите PIN-код в корректном формате")]
        [Required(ErrorMessage = "Введите PIN-код")]
        public string CreditCardPIN { get; set; } = default!;
    }
}
