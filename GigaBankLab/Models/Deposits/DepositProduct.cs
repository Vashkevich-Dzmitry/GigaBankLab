using System.ComponentModel.DataAnnotations;

namespace GigaBankLab.Models
{
    public class DepositProduct
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Описание")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Длительность")]
        public int Duration { get; set; }

        [Display(Name = "Процент")]
        public double Percent { get; set; }

        [Display(Name = "Валюта")]
        public int CurrencyId { get; set; }
        public Currency? Currency { get; set; }

        [Display(Name = "Отзывность")]
        public bool IsRevocable { get; set; }    

        [Display(Name = "Частичное снятие")]
        public bool IsPartialWithdrawal { get; set; }
    }
}
