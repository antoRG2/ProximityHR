using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proximity.HR.Web.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        public int EmployeeNumber { get; set; }

        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }
        
        [StringLength(25)]
        public string MaritalStatus { get; set; }

        [StringLength(25)]
        public string Dependents { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [StringLength(100)]
        public string EndReason { get; set; }

        [StringLength(25)]
        public string Nationality { get; set; }

        [StringLength(100)]
        public string Detail { get; set; }

        [StringLength(25)]
        public string PrimaryPhoneNumber { get; set; }

        [StringLength(25)]
        public string SecondaryPhoneNumber { get; set; }

        [StringLength(25)]
        public string EmergencyPhoneNumber { get; set; }

        [StringLength(50)]
        public string EmergencyContactName { get; set; }

        [StringLength(50)]
        public string PersonalEmail { get; set; }

        [StringLength(50)]
        public string NotificationsEmail { get; set; }

        [StringLength(25)]
        public string Schooling { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string District { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        //[StringLength(25)]
        //public string Picture { get; set; } //TODO: check this field

        public bool HasPassport { get; set; }

        [StringLength(25)]
        public string PassportNumber { get; set; }

        [StringLength(50)]
        public string PassportIssueCity { get; set; }

        public DateTime PassportExpeditionDate { get; set; }

        public DateTime PassportExpirationnDate { get; set; }

        public bool HasVisa { get; set; }

        [StringLength(25)]
        public string VisaNumber { get; set; }

        [StringLength(50)]
        public string VisaIssueCity { get; set; }

        public DateTime VisaExpeditionDate { get; set; }

        public DateTime VisaExpirationnDate { get; set; }

        public bool Enabled { get; set; }


        //public string Identification { get; set; } //TODO: ask for this field

       
    }
}