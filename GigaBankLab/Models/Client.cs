using System.ComponentModel.DataAnnotations;

namespace GigaBankLab.Models
{
    public class Client
    {
        public int Id { get; set; } 

        public string LastName { get; set; }
        public string FirstName { get; set; } 
        public string Patronymic { get; set; } 

        
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; } 

        public string PassportSeries { get; set; } 
        public string PassportNumber { get; set; }

        public string IssuingAuthority { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; } 

        public string IdentificationNumber { get; set; } 

        public string PlaceOfBirth { get; set; } 
        
        public int CityOfResidenceId { get; set; } 
        public City CityOfResidence { get; set; } 

        public string ResidentialAddress { get; set; } 

        public string? HomePhone { get; set; } 
        public string? MobilePhone { get; set; } 
        public string? Email { get; set; } 
        public string? Workplace { get; set; } 
        public string? Position { get; set; } 
        public decimal? MonthlyIncome { get; set; } 

        public int MaritalStatusId { get; set; }
        public MaritalStatus MaritalStatus { get; set; } 

        public int CitizenshipId { get; set; }
        public Citizenship Citizenship { get; set; } 

        public int DisabilityId { get; set; }
        public Disability Disability { get; set; } 

        public bool IsPensioner { get; set; } 
        public bool IsMilitaryServiceRequired { get; set; } 

    }
}
