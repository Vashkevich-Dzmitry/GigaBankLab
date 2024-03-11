using System.ComponentModel.DataAnnotations;

namespace GigaBankLab.Models
{
    public class CreditProduct
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
        public Currency? Currency { get; set; }
        [Display(Name = "Валюта")]
        public int CurrencyId { get; set; }

        [Display(Name = "Выплаты равными частями")]
        public bool Annuity { get; set; }
    }
}
