using System.ComponentModel.DataAnnotations;

namespace GigaBankLab.Models
{
    public class Citizenship
    {
        [Display(Name = "Гражданство")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}