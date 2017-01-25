using Proximity.HR.Models.Dto;
using Proximity.HR.Models.ErrorHandler;
using Proximity.HR.Services.Service;
using System;
using System.Web.Http;
using System.Web.Security;

namespace Proximity.HR.Web.Controllers
{
    public class AccountController : ApiController
    {
        private AccountService _service = new AccountService();

        [ActionName("GetADAccounts")]
        public GenericResponse<ActiveDirecotryAccountsDto> GetADAccounts()
        {
            var result = new BasicResponse<ActiveDirecotryAccountsDto>();

            try
            {
                result.Response = _service.GetADAccounts();
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        [ActionName("GetUserByUserName")]
        public GenericResponse<UsersDto> GetUserByUserName(string userName)
        {
            var result = new BasicResponse<UsersDto>();

            try
            {
                result.Response = _service.GetUserById(userName);
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }
        
        [ActionName("PostAuthenticate")]
        public GenericResponse<UserDto> PostAuthenticate(UserDto user)
        {
            var result = new BasicResponse<UserDto>();
            try
            {
                //if (Membership.ValidateUser(user.UserName, user.Password))
                //{
                    result.Response = _service.GetUserById(user.UserName)[0];
                    result.Status = ResponseCode.Success;

                FormsAuthentication.SetAuthCookie(user.UserName, true);
            //}
            //    else
            //    {
            //    result.Status = ResponseCode.Error;
            //    result.Message = "Invalid Login";
            //}
        }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Message = "Error establishing connection with Active Directory" + result.Status + result.Response;
                result.Exception = e;
                
            }
            return result;
        }

        [ActionName("PostSaveUser")]
        public GenericResponse<int> PostSaveUser(UserDto user)
        {
            var result = new BasicResponse<int>();

            try
            {
                result.Response = _service.AddUser(user);
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        [ActionName("UpdateUser")]
        public GenericResponse<bool> UpdateUser(UserDto user)
        {
            var result = new BasicResponse<bool>();

            try
            {
                result.Response = _service.UpdateUser(user);
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Response = false;
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        [ActionName("DeleteUser")]
        public GenericResponse<bool> DeleteEmployee(UserDto user)
        {
            var result = new BasicResponse<bool>();

            try
            {
                result.Response = _service.DeleteUser(user);
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Response = false;
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }
    }
}
