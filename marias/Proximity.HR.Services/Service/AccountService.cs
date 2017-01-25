using AutoMapper;
using Proximity.HR.Data;
using Proximity.HR.Data.Repository;
using Proximity.HR.Models.Dto;
using Proximity.HR.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proximity.HR.Services.Service
{
    public class AccountService
    {
        public AccountService()
        {
            MappingBase.Configure();
        }

        public ActiveDirecotryAccountsDto GetADAccounts()
        {
            var result = new ActiveDirecotryAccountsDto();

            string domainPath = ConfigurationManager.AppSettings["ADCnn"].ToString();

            // string domainPath = "LDAP://52.25.33.154/DC=isthmusit,DC=com";
            DirectoryEntry searchRoot = new DirectoryEntry(domainPath);
            DirectorySearcher search = new DirectorySearcher(searchRoot);
            //searchRoot.Username = "appinternal";
            searchRoot.Username = ConfigurationManager.AppSettings["ADUser"].ToString();
            //searchRoot.Password = "password.1";
            searchRoot.Password = ConfigurationManager.AppSettings["ADPass"].ToString();
            search.Filter = "(&(objectClass=user)(objectCategory=person))";
            search.PropertiesToLoad.Add("samaccountname");
            search.PropertiesToLoad.Add("mail");
            search.PropertiesToLoad.Add("usergroup");
            search.PropertiesToLoad.Add("displayname");

            SearchResult searchResult;
            SearchResultCollection resultCol = search.FindAll();
            if (resultCol != null)
            {
                for (int counter = 0; counter < resultCol.Count; counter++)
                {
                    string UserNameEmailString = string.Empty;
                    searchResult = resultCol[counter];
                    if (searchResult.Properties.Contains("samaccountname") &&
                        searchResult.Properties.Contains("mail") &&
                        searchResult.Properties.Contains("displayname"))
                    {

                        result.Add(
                            new ActiveDirecotryAccountDto
                                {
                                    AccountName = (String)searchResult.Properties["samaccountname"][0],
                                    Email = (String)searchResult.Properties["mail"][0] + "^" +
                                            (String)searchResult.Properties["displayname"][0],
                                    DisplayName = (String)searchResult.Properties["displayname"][0],
                                    UserGroup = ""
                                }
                            );
                    }
                }
            }

            return result;
        }

        public UsersDto GetUsers()
        {
            var result = new UsersDto();
            using (var unitOfWork = new UnitOfWork())
            {
                var data = unitOfWork.GetRepositoryInstance<User>().Get().ToList();
                result.AddRange(from User user in data
                                where user.Enabled == true
                                select Mapper.Map<User, UserDto>(user));
            }
            return result;
        }

        public UsersDto GetUserById(string userName)
        {
            var result = new UsersDto();
            using (var unitOfWork = new UnitOfWork())
            {
                var data = unitOfWork.GetRepositoryInstance<User>().Find(x => x.UserName == userName).ToList();
                result.AddRange(from User user in data
                                where user.Enabled == true
                                select Mapper.Map<User, UserDto>(user));
            }
            return result;
        }

        public int AddUser(UserDto user)
        {
            var userToProcess = Mapper.Map<User>(user);
            var EmployeeToProcess = new Employee();

            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.GetRepositoryInstance<User>();
                userToProcess.Employees = new List<Employee>();
                userToProcess.Employees.Add(
                    new Employee()
                    {
                        Name = user.DisplayName,
                        FirstLastName = "",
                        SecondLastName = "",
                        Gender = 1,
                        Address = "",
                        BirthDate = DateTime.Now,
                        City = 1,
                        Country = 1,
                        CreatedBy = userToProcess.CreatedBy,
                        CreatedDate = userToProcess.CreatedDate,
                        EditedBy = userToProcess.EditedBy,
                        EditedDate = userToProcess.EditedDate,
                        EmergencyContact = "",
                        Dependents = 0,
                        Detail = "",
                        District = 1,
                        EmergencyPhoneNumber = "",
                        EmployeeNumber = 0,
                        Enabled = true,
                        EndDate = DateTime.Now,
                        EndReason = "",
                        HasPassport = false,
                        HasVisa = false,
                        HasLicense = false,
                        Identification = "",
                        MaritalStatus = 1,
                        Nationality = "Costarricense",
                        NotificationsEmail = "",
                        UserId = userToProcess.Id,
                        State = 1,
                        Schooling = 1,
                        StartDate = DateTime.Now,
                        VisaNumber = "0",
                        PassportNumber = "0",
                        PassportExpeditionDate = DateTime.Now,
                        PassportExpirationDate = DateTime.Now,
                        VisaExpeditionDate = DateTime.Now,
                        VisaExpirationDate = DateTime.Now,
                        VisaIssueCity = 0,
                        PrimaryPhoneNumber = "",
                        SecundaryPhoneNumber = "",
                        PersonalEmail = "",
                        PassportIssueCity = 0,
                        Picture = "",
                        FullName = user.DisplayName,

                    }
                    );

                repository.Add(userToProcess);
                repository.Save();



            }
            return userToProcess.Id;
        }

        public bool UpdateUser(UserDto user)
        {
            var UserToProcess = Mapper.Map<User>(user);
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.GetRepositoryInstance<User>();
                repository.Edit(UserToProcess);
                repository.Save();
            }
            return true;
        }

        public bool DeleteUser(UserDto user)
        {
            var UserToProcess = Mapper.Map<User>(user);
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.GetRepositoryInstance<User>();
                repository.Delete(UserToProcess);
                repository.Save();
            }
            return true;
        }
    }
}
