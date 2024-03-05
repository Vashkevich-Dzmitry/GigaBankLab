using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigaBankLab.Models
{
    public static class AccountConstants
    {
        public const string CashboxAccountCode = "1010";
        public const string BankGrowthFundAccountCode = "7327";
        public const string CurrentAccountCode = "3014";
        public const string PercentAccountCode = "3470";
    }

    public class Account
    {
        public int Id { get; set; }

        [Display(Name = "Номер счета")]
        public string Number { get; set; } = string.Empty;

        [Display(Name = "Кредит")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Credit { get; set; }

        [Display(Name = "Дебет")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Debit { get; set; }

        [Display(Name = "Сальдо")]
        public decimal Balance { get => Debit - Credit; }

        [Display(Name = "Клиент")]
        public int? ClientId { get; set; }
        public Client? Client { get; set; }

        [Display(Name = "Тип счета")]
        public AccountType Type{ get; set; }

        [Display(Name = "Валюта")]
        public int CurrencyId { get; set; }
        public Currency? Currency { get; set; }

        public static string GenerateNumber(string accountCode, int clientId, int accountId)
        {
            var numberPrefix = $"{accountCode}{(clientId % 100000):D05}{(accountId % 1000):D03}";
            int controlNumber = numberPrefix.Sum(c => c - '0') % 10;
            return numberPrefix + controlNumber;
        }
    }
}
