using System.ComponentModel.DataAnnotations;

namespace GigaBankLab.Models
{
    public class Disability
    {
        [Display(Name = "Инвалидность")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}