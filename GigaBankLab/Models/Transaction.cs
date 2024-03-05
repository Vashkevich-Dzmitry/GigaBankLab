using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigaBankLab.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Display(Name = "Дата и время")]
        public DateTime DateTime { get; set; }

        [Display(Name = "Отправитель")]
        public int FromAccountId { get; set; }
        [Display(Name = "Отправитель")]
        public Account? FromAccount { get; set; }

        [Display(Name = "Получатель")]
        public int ToAccountId { get; set; }
        [Display(Name = "Получатель")]
        public Account? ToAccount { get; set; }

        [Display(Name = "Сумма")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Sum { get; set; }
    }
}
