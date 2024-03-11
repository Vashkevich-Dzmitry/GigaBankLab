using System.ComponentModel.DataAnnotations;

namespace GigaBankLab.Models.Atm
{
    public class AtmCashWithdrawalDTO
    {
        [Display(Name = "Кредитный договор")]
        public int CreditContractId { get; set; }

        [Display(Name = "Сумма")]
        [Required(ErrorMessage = "Введите сумму")]
        public decimal Sum { get; set; }
    }
}
