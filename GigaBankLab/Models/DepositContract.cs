﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigaBankLab.Models
{
    public class DepositContract : IValidatableObject
    {
        public int Id { get; set; }


        [Display(Name = "Основной счёт")]
        public int CurrentAccountId { get; set; }
        public Account? CurrentAccount { get; set; }
        [Display(Name = "Процентный счёт")]
        public int PercentAccountId { get; set; }
        public Account? PercentAccount { get; set; }

        [Display(Name = "Клиент")]
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        [Display(Name = "Депозит")]
        public int DepositId { get; set; }
        public Deposit? Deposit { get; set; }

        [Display(Name = "Дата открытия")]
        [DataType(DataType.Date)]
        public DateTime OpenDate { get; set; }

        [Display(Name = "Дата закрытия")]
        [DataType(DataType.Date)]
        public DateTime CloseDate { get; set; }

        [Display(Name = "Сумма")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Sum { get; set; }

        public bool IsClosed { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Sum <= 0)
            {
                yield return new ValidationResult("Сумма должна быть больше нуля", new[] { nameof(Sum) });
            }
        }
    }
}