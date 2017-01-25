using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Proximity.HR.Models.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EmployeeNumber { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string FullName { get; set; }
        public int Gender { get; set; }
        public int MaritalStatus { get; set; }
        public int Dependents { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string EndReason { get; set; }
        public string Nationality { get; set; }
        public string Detail { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string SecundaryPhoneNumber { get; set; }
        public string EmergencyPhoneNumber { get; set; }
        public string EmergencyContact { get; set; }
        public string PersonalEmail { get; set; }
        public string NotificationsEmail { get; set; }
        public int Schooling { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
        public int City { get; set; }
        public int District { get; set; }
        public string Address { get; set; }
        public string Picture { get; set; }
        public bool HasPassport { get; set; }
        public string PassportNumber { get; set; }
        public Nullable<int> PassportIssueCity { get; set; }
        public Nullable<System.DateTime> PassportExpeditionDate { get; set; }
        public Nullable<System.DateTime> PassportExpirationDate { get; set; }
        public bool HasVisa { get; set; }
        public string VisaNumber { get; set; }
        public Nullable<int> VisaIssueCity { get; set; }
        public Nullable<System.DateTime> VisaExpeditionDate { get; set; }
        public Nullable<System.DateTime> VisaExpirationDate { get; set; }
        public bool HasLicense { get; set; }
        public string LicenseNumber { get; set; }
        public Nullable<System.DateTime> LicenseExpeditionDate { get; set; }
        public Nullable<System.DateTime> LicenseExpirationDate { get; set; }
        public bool Enabled { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string EditedBy { get; set; }
        public Nullable<System.DateTime> EditedDate { get; set; }
   
        //public virtual CityDto City1 { get; set; }
        //public virtual CountryDto Country { get; set; }
        //public virtual DistrictDto District1 { get; set; }
        //public virtual StateDto State1 { get; set; }
        //public virtual ICollection<SkillDto> SkillSets { get; set; }
       // public virtual UserDto User { get; set; }
    }

    [KnownType(typeof(EmployeeDto))]
    public class EmployeesDto : List<EmployeeDto> { }
}
