using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigaBankLab.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Display(Name = "Фамилия")]
        [RegularExpression(@"[А-ЯЁ][а-яё]+", ErrorMessage = "Фамилия должна начинаться с заглавной буквы и не содержать иных символов, кроме букв")]
        [Required(ErrorMessage = "Заполните поле Фамилия")]
        public string LastName { get; set; } = string.Empty;


        [Display(Name = "Имя")]
        [RegularExpression(@"[А-ЯЁ][а-яё]+", ErrorMessage = "Имя должно начинаться с заглавной буквы и не содержать иных символов, кроме букв")]
        [Required(ErrorMessage = "Заполните поле ")]
        public string FirstName { get; set; } = string.Empty;


        [Display(Name = "Отчество")]
        [RegularExpression(@"[А-ЯЁ][а-яё]+", ErrorMessage = "Отчество должно начинаться с заглавной буквы и не содержать иных символов, кроме букв")]
        [Required(ErrorMessage = "Заполните поле Отчество")]
        public string Patronymic { get; set; } = string.Empty;


        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Заполните поле Дата рождения")]
        public DateTime DateOfBirth { get; set; }


        [Display(Name = "Серия паспорта")]
        [RegularExpression(@"[A-Z]{2}", ErrorMessage = "Введите серию паспорта, которая состоит из двух прописных латинских букв!")]
        [Required(ErrorMessage = "Заполните поле Серия паспорта")]
        public string PassportSeries { get; set; } = string.Empty;


        [Display(Name = "Номер паспорта")]
        [RegularExpression(@"\d{7}", ErrorMessage = "Введите 7 цифр номера паспорта")]
        [Required(ErrorMessage = "Заполните поле Номер паспорта")]
        public string PassportNumber { get; set; } = string.Empty;


        [Display(Name = "Кем выдан")]
        [Required(ErrorMessage = "Заполните поле Кем выдан")]
        public string IssuingAuthority { get; set; } = string.Empty;


        [DataType(DataType.Date)]
        [Display(Name = "Дата выдачи")]
        [Required(ErrorMessage = "Заполните поле Дата выдачи")]
        public DateTime IssueDate { get; set; }


        [Display(Name = "Идентификационный номер")]
        [RegularExpression(@"\d{7}[A-Z][A-Z0-9]{3}[A-Z]{2}\d", ErrorMessage = "Введите идентификационный номер в корректном формате")]
        [Required(ErrorMessage = "Заполните поле Идентификационный номер")]
        public string IdentificationNumber { get; set; } = string.Empty;



        [Display(Name = "Место рождения")]
        [Required(ErrorMessage = "Заполните поле Место рождения")]
        public string PlaceOfBirth { get; set; } = string.Empty;


        [Display(Name = "Город проживания")]
        [Required(ErrorMessage = "Заполните поле Город проживания")]
        public int CityOfResidenceId { get; set; }
        [Display(Name = "Город проживания")]
        public City? CityOfResidence { get; set; }


        [Display(Name = "Адрес проживания")]
        [Required(ErrorMessage = "Заполните поле Адрес проживания")]
        public string ResidentialAddress { get; set; } = string.Empty;


        [Display(Name = "Телефон дом.")]
        [RegularExpression(@"[+]375\(\d{2}\)\d{7}", ErrorMessage = "Введите номер в корректном формате")]
        public string? HomePhone { get; set; }

        [Display(Name = "Телефон моб.")]
        [RegularExpression(@"[+]375\(\d{2}\)\d{7}", ErrorMessage = "Введите номер в корректном формате")]
        public string? MobilePhone { get; set; }

        [Display(Name = "E-mail")]
        public string? Email { get; set; } 
        
        [Display(Name = "Место работы")]
        public string? Workplace { get; set; }
        [Display(Name = "Должность")]
        public string? Position { get; set; }

        [Display(Name = "Ежемесячный доход")]
        public decimal? MonthlyIncome { get; set; }


        [Display(Name = "Семейное положение")]
        [Required(ErrorMessage = "Заполните поле Семейное положение")]
        public int MaritalStatusId { get; set; }
        [Display(Name = "Семейное положение")]
        public MaritalStatus? MaritalStatus { get; set; }


        [Display(Name = "Гражданство")]
        [Required(ErrorMessage = "Заполните поле Гражданство")]
        public int CitizenshipId { get; set; }
        [Display(Name = "Гражданство")]
        public Citizenship? Citizenship { get; set; }


        [Display(Name = "Инвалидность")]
        [Required(ErrorMessage = "Заполните поле Инвалидность")]
        public int DisabilityId { get; set; }
        [Display(Name = "Инвалидность")]
        public Disability? Disability { get; set; }


        [Display(Name = "Пенсионер")]
        [Required(ErrorMessage = "Заполните поле Пенсионер")]
        public bool IsPensioner { get; set; }


        [Display(Name = "Военнообязанный")]
        [Required(ErrorMessage = "Заполните поле Военнообязанный")]
        public bool IsMilitaryServiceRequired { get; set; } 

    }
}
