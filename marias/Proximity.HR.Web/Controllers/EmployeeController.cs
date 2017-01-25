using Proximity.HR.Models.Dto;
using Proximity.HR.Models.ErrorHandler;
using Proximity.HR.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proximity.HR.Web.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeService _service = new EmployeeService();

        [ActionName("GetEmployees")]
        public GenericResponse<EmployeesDto> GetEmployees()
        {
            var result = new BasicResponse<EmployeesDto>();

            try
            {
                result.Response = _service.GetEmployees();
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        [ActionName("GetEmployeeById")]
        public GenericResponse<EmployeesDto> GetEmployeeById(int employeeId)
        {
            var result = new BasicResponse<EmployeesDto>();

            try
            {
                result.Response = _service.GetEmployeeById(employeeId);
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        [ActionName("GetEmployeeByUserName")]
        public GenericResponse<EmployeesDto> GetEmployeeByUserName(string userName)
        {
            var result = new BasicResponse<EmployeesDto>();

            try
            {
                result.Response = _service.GetEmployeeByUserName(userName);
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        [ActionName("PostEmployee")]
        public GenericResponse<int> PostEmployee(EmployeeDto employee)
        {
            var result = new BasicResponse<int>();

            try
            {
                result.Response = _service.AddEmployee(employee);
                result.Status = ResponseCode.Success;
            }
            catch (Exception e)
            {
                result.Status = ResponseCode.Error;
                result.Exception = e;
            }

            return result;
        }

        [ActionName("UpdateEmployee")]
        public GenericResponse<bool> UpdateEmployee(EmployeeDto employee)
        {
            var result = new BasicResponse<bool>();

            try
            {
                result.Response = _service.UpdateEmployee(employee);
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

        [ActionName("DeleteEmployee")]
        public GenericResponse<bool> DeleteEmployee(EmployeeDto employee)
        {
            var result = new BasicResponse<bool>();

            try
            {
                result.Response = _service.DeleteEmployee(employee);
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
