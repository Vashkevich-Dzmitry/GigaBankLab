using System.ComponentModel.DataAnnotations;

namespace GigaBankLab.Models
{
    public class CurrentDate
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Value { get; set; }
    }
}
