using System.ComponentModel.DataAnnotations;

namespace GigaBankLab.Models
{
    public class Currency
    {
        [Display(Name = "Валюта")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}