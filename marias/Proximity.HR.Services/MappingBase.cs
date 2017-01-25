using AutoMapper;
using Proximity.HR.Data;
using Proximity.HR.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proximity.HR.Services;

namespace Proximity.HR.Service
{
    public class MappingBase
    {
        public static void Configure()
        {
            Mapper.CreateMap<City, GeneralCollectionItemDto>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Display, opt => opt.MapFrom(src => src.Name));

            Mapper.CreateMap<State, GeneralCollectionItemDto>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Display, opt => opt.MapFrom(src => src.Name));

            Mapper.CreateMap<Country, GeneralCollectionItemDto>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Display, opt => opt.MapFrom(src => src.Name));

            Mapper.CreateMap<District, GeneralCollectionItemDto>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Display, opt => opt.MapFrom(src => src.Name));

            Mapper.CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.Identification))
                .ForMember(dest => dest.EmployeeNumber, opt => opt.MapFrom(src => src.EmployeeNumber))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.FirstLastName, opt => opt.MapFrom(src => src.FirstLastName))
                .ForMember(dest => dest.SecondLastName, opt => opt.MapFrom(src => src.SecondLastName))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => src.MaritalStatus))
                .ForMember(dest => dest.Dependents, opt => opt.MapFrom(src => src.Dependents))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.EndReason, opt => opt.MapFrom(src => src.EndReason))
                .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Nationality))
                .ForMember(dest => dest.Detail, opt => opt.MapFrom(src => src.Detail))
                .ForMember(dest => dest.PrimaryPhoneNumber, opt => opt.MapFrom(src => src.PrimaryPhoneNumber))
                .ForMember(dest => dest.SecundaryPhoneNumber, opt => opt.MapFrom(src => src.SecundaryPhoneNumber))
                .ForMember(dest => dest.EmergencyPhoneNumber, opt => opt.MapFrom(src => src.EmergencyPhoneNumber))
                .ForMember(dest => dest.EmergencyContact, opt => opt.MapFrom(src => src.EmergencyContact))
                .ForMember(dest => dest.PersonalEmail, opt => opt.MapFrom(src => src.PersonalEmail))
                .ForMember(dest => dest.NotificationsEmail, opt => opt.MapFrom(src => src.NotificationsEmail))
                .ForMember(dest => dest.Schooling, opt => opt.MapFrom(src => src.Schooling))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Picture, opt => opt.MapFrom(src => src.Picture))
                .ForMember(dest => dest.HasPassport, opt => opt.MapFrom(src => src.HasPassport))
                .ForMember(dest => dest.PassportNumber, opt => opt.MapFrom(src => src.PassportNumber))
                .ForMember(dest => dest.PassportIssueCity, opt => opt.MapFrom(src => src.PassportIssueCity))
                .ForMember(dest => dest.PassportExpeditionDate, opt => opt.MapFrom(src => src.PassportExpeditionDate))
                .ForMember(dest => dest.PassportExpirationDate, opt => opt.MapFrom(src => src.PassportExpirationDate))
                .ForMember(dest => dest.HasVisa, opt => opt.MapFrom(src => src.HasVisa))
                .ForMember(dest => dest.VisaNumber, opt => opt.MapFrom(src => src.VisaNumber))
                .ForMember(dest => dest.VisaIssueCity, opt => opt.MapFrom(src => src.VisaIssueCity))
                .ForMember(dest => dest.VisaExpeditionDate, opt => opt.MapFrom(src => src.VisaExpeditionDate))
                .ForMember(dest => dest.VisaExpirationDate, opt => opt.MapFrom(src => src.VisaExpirationDate))
                .ForMember(dest => dest.HasLicense, opt => opt.MapFrom(src => src.HasLicense))
                .ForMember(dest => dest.LicenseNumber, opt => opt.MapFrom(src => src.LicenseNumber))
                .ForMember(dest => dest.LicenseExpeditionDate, opt => opt.MapFrom(src => src.LicenseExpeditionDate))
                .ForMember(dest => dest.LicenseExpirationDate, opt => opt.MapFrom(src => src.LicenseExpirationDate))
                .ForMember(dest => dest.Enabled, opt => opt.MapFrom(src => src.Enabled))
                .ForMember(dest => dest.Enabled, opt => opt.MapFrom(src => src.Enabled))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.EditedBy, opt => opt.MapFrom(src => src.EditedBy))
                .ForMember(dest => dest.EditedDate, opt => opt.MapFrom(src => src.EditedDate));
                //.ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));

            Mapper.CreateMap<EmployeeDto, Employee>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))     
               .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.Identification))
               .ForMember(dest => dest.EmployeeNumber, opt => opt.MapFrom(src => src.EmployeeNumber))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.FirstLastName, opt => opt.MapFrom(src => src.FirstLastName))
               .ForMember(dest => dest.SecondLastName, opt => opt.MapFrom(src => src.SecondLastName))
               .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
               .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => src.MaritalStatus))
               .ForMember(dest => dest.Dependents, opt => opt.MapFrom(src => src.Dependents))
               .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
               .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
               .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
               .ForMember(dest => dest.EndReason, opt => opt.MapFrom(src => src.EndReason))
               .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Nationality))
               .ForMember(dest => dest.Detail, opt => opt.MapFrom(src => src.Detail))
               .ForMember(dest => dest.PrimaryPhoneNumber, opt => opt.MapFrom(src => src.PrimaryPhoneNumber))
               .ForMember(dest => dest.SecundaryPhoneNumber, opt => opt.MapFrom(src => src.SecundaryPhoneNumber))
               .ForMember(dest => dest.EmergencyPhoneNumber, opt => opt.MapFrom(src => src.EmergencyPhoneNumber))
               .ForMember(dest => dest.EmergencyContact, opt => opt.MapFrom(src => src.EmergencyContact))
               .ForMember(dest => dest.PersonalEmail, opt => opt.MapFrom(src => src.PersonalEmail))
               .ForMember(dest => dest.NotificationsEmail, opt => opt.MapFrom(src => src.NotificationsEmail))
               .ForMember(dest => dest.Schooling, opt => opt.MapFrom(src => src.Schooling))
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
               .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
               .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
               .ForMember(dest => dest.Picture, opt => opt.MapFrom(src => src.Picture))
               .ForMember(dest => dest.HasPassport, opt => opt.MapFrom(src => src.HasPassport))
               .ForMember(dest => dest.PassportNumber, opt => opt.MapFrom(src => src.PassportNumber))
               .ForMember(dest => dest.PassportIssueCity, opt => opt.MapFrom(src => src.PassportIssueCity))
               .ForMember(dest => dest.PassportExpeditionDate, opt => opt.MapFrom(src => src.PassportExpeditionDate))
               .ForMember(dest => dest.PassportExpirationDate, opt => opt.MapFrom(src => src.PassportExpirationDate))
               .ForMember(dest => dest.HasVisa, opt => opt.MapFrom(src => src.HasVisa))
               .ForMember(dest => dest.VisaNumber, opt => opt.MapFrom(src => src.VisaNumber))
               .ForMember(dest => dest.VisaIssueCity, opt => opt.MapFrom(src => src.VisaIssueCity))
               .ForMember(dest => dest.VisaExpeditionDate, opt => opt.MapFrom(src => src.VisaExpeditionDate))
               .ForMember(dest => dest.VisaExpirationDate, opt => opt.MapFrom(src => src.VisaExpirationDate))
               .ForMember(dest => dest.HasLicense, opt => opt.MapFrom(src => src.HasLicense))
               .ForMember(dest => dest.LicenseNumber, opt => opt.MapFrom(src => src.LicenseNumber))
               .ForMember(dest => dest.LicenseExpeditionDate, opt => opt.MapFrom(src => src.LicenseExpeditionDate))
               .ForMember(dest => dest.LicenseExpirationDate, opt => opt.MapFrom(src => src.LicenseExpirationDate))
               .ForMember(dest => dest.Enabled, opt => opt.MapFrom(src => src.Enabled))
               .ForMember(dest => dest.Enabled, opt => opt.MapFrom(src => src.Enabled))
               .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
               .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
               .ForMember(dest => dest.EditedBy, opt => opt.MapFrom(src => src.EditedBy))
               .ForMember(dest => dest.EditedDate, opt => opt.MapFrom(src => src.EditedDate));
               //.ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));
            //  .ForMember(dest => dest.SkillSets, opt => opt.Ignore());

            Mapper.CreateMap<Technology, TechnologyDto>();

            Mapper.CreateMap<Feature, FeatureDto>();

            Mapper.CreateMap<TechnologyDto, Technology>();

            Mapper.CreateMap<FeatureDto, Feature>();

            Mapper.CreateMap<SkillSetDto, SkillSet>();
            Mapper.CreateMap<SkillSet, SkillSetDto>();

            Mapper.CreateMap<User, UserDto>();

            Mapper.CreateMap<UserDto, User>();
        }
    }
}
