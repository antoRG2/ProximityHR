using AutoMapper;
using Proximity.HR.Data;
using Proximity.HR.Data.Repository;
using Proximity.HR.Models.Dto;
using Proximity.HR.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proximity.HR.Services.Service
{
    public class EmployeeService
    {
        public EmployeeService()
        {
            MappingBase.Configure();
        }

        public EmployeesDto GetEmployees()
        {
            var result = new EmployeesDto();
            using (var unitOfWork = new UnitOfWork())
            {
                var data = unitOfWork.GetRepositoryInstance<Employee>().Get().ToList();
                result.AddRange(from Employee employee in data
                                where employee.Enabled == true
                                select Mapper.Map<Employee, EmployeeDto>(employee));
            }

            return result;
        }

        public EmployeesDto GetEmployeeById(int employeeId)
        {
            var result = new EmployeesDto();
            using (var unitOfWork = new UnitOfWork())
            {
                var data = unitOfWork.GetRepositoryInstance<Employee>().Find(x => x.Id == employeeId).ToList();
                result.AddRange(from Employee employee in data
                                where employee.Enabled == true
                                select Mapper.Map<Employee, EmployeeDto>(employee));
            }
            return result;
        }

        public EmployeesDto GetEmployeeByUserName(string userName)
        {
            var result = new EmployeesDto();
            using (var unitOfWork = new UnitOfWork())
            {
                var data = unitOfWork.GetRepositoryInstance<Employee>().Find(x => x.User.UserName == userName).ToList();
                result.AddRange(from Employee employee in data
                                where employee.Enabled == true
                                select Mapper.Map<Employee, EmployeeDto>(employee));
            }
            return result;
        }

        public int AddEmployee(EmployeeDto employee)
        {
            var employeeToProcess = Mapper.Map<Employee>(employee);
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.GetRepositoryInstance<Employee>();

                employeeToProcess.CreatedDate = DateTime.Today;
                employeeToProcess.FullName = employeeToProcess.Name + ' ' + employeeToProcess.FirstLastName + ' ' + employeeToProcess.SecondLastName;
                repository.Add(employeeToProcess);
                repository.Save();
            }
            return employeeToProcess.Id;
        }

        public bool UpdateEmployee(EmployeeDto employee)
        {
            var employeeToProcess = Mapper.Map<Employee>(employee);
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.GetRepositoryInstance<Employee>();
                employeeToProcess.EditedDate = DateTime.Now;
                employeeToProcess.CreatedDate = DateTime.Now;
                employeeToProcess.EditedBy = "admnin";

                employeeToProcess.FullName = employeeToProcess.Name + ' ' + employeeToProcess.FirstLastName + ' ' + employeeToProcess.SecondLastName;
                repository.Edit(employeeToProcess);
                repository.Save();
            }
            return true;
        }

        public bool DeleteEmployee(EmployeeDto employee)
        {
            var employeeToProcess = Mapper.Map<Employee>(employee);
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.GetRepositoryInstance<Employee>();
                repository.Delete(employeeToProcess);
                repository.Save();
            }
            return true;
        }
    }
}
