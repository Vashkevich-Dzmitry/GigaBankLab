using System.ComponentModel.DataAnnotations;

namespace GigaBankLab.Models
{
    public class MaritalStatus
    {
        [Display(Name = "Семейное положение")]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}