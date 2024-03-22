using EmployeeRecord.DTOs;
using EmployeeRecord.Models;
using EmployeeRecord.Responses;
using EmployeeRecord.Services;

namespace EmployeeRecord.Interface
{
    public interface IAccountService
    {

        Task<ServiceResponse<Employee>> CreateAccountAsync(CreateAccountDto payload);
        //Task<dynamic> CreateAccountAsync(CreateAccountDto payload);

        Task<ServiceResponse<List<Employee>>> GetAllRecords();
        // Task<dynamic> GetAllRecords();
        Task<ServiceResponse<Employee>> GetRecordById(string EmployeeId);
        //Task<dynamic> GetRecordById(string EmployeeId);

        Task<ServiceResponse<Employee>> UpdateAccountAsync(CreateAccountDto payload);
        //Task<dynamic> UpdateAccountAsync(CreateAccountDto payload);

        Task<ServiceResponse<Employee>> DeleteRecordById(string EmployeeId);
        //Task<dynamic> DeleteRecordById(string EmployeeId);


    }
}
