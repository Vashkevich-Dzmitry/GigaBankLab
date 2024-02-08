using System.ComponentModel.DataAnnotations;

namespace GigaBankLab.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; } 

        
        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Серия паспорта")]
        public string PassportSeries { get; set; }
        [Display(Name = "Номер паспорта")]
        public string PassportNumber { get; set; }

        [Display(Name = "Кем выдан")]
        public string IssuingAuthority { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Дата выдачи")]
        public DateTime IssueDate { get; set; }

        [Display(Name = "Идентификационный номер")]
        public string IdentificationNumber { get; set; }

        [Display(Name = "Место рождения")]
        public string PlaceOfBirth { get; set; }


        [Display(Name = "Город")]
        public int CityOfResidenceId { get; set; } 
        [Display(Name = "Город")]
        public City? CityOfResidence { get; set; }


        [Display(Name = "Адрес")]
        public string ResidentialAddress { get; set; }

        [Display(Name = "Телефон дом.")]
        public string? HomePhone { get; set; }
        [Display(Name = "Телефон моб.")]
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
        public int MaritalStatusId { get; set; }
        [Display(Name = "Семейное положение")]
        public MaritalStatus? MaritalStatus { get; set; }

        [Display(Name = "Гражданство")]
        public int CitizenshipId { get; set; }
        [Display(Name = "Гражданство")]
        public Citizenship? Citizenship { get; set; }

        [Display(Name = "Инвалидность")]
        public int DisabilityId { get; set; }
        [Display(Name = "Инвалидность")]
        public Disability? Disability { get; set; }

        [Display(Name = "Пенсионер")]
        public bool IsPensioner { get; set; }
        [Display(Name = "Военнообязанный")]
        public bool IsMilitaryServiceRequired { get; set; } 

    }
}
