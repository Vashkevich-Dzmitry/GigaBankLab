using System.ComponentModel.DataAnnotations;

namespace GigaBankLab.Models
{
    public class City
    {
        [Display(Name = "Город проживания")]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
