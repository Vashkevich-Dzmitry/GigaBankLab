using System;
using System.ComponentModel.DataAnnotations;

namespace GigaBankLab.Models
{
    public class CurrentDate
    {
        public int Id { get; set; }
        // [DisplayFormat(DataFormatString = "{dd MM yyyy}")]

        [DataType(DataType.Date)]
        public DateTime Value { get; set; }
    }
}
