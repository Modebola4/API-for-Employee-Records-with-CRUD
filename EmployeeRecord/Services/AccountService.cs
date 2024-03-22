using EmployeeRecord.DTOs;
using EmployeeRecord.Interface;
using EmployeeRecord.Models;
using EmployeeRecord.Responses;
using System.Net;
using System.Xml.Linq;

namespace EmployeeRecord.Services
{

    public class AccountService : IAccountService
    {
        private static List<Employee> employees = new List<Employee>
    {
            new Employee{
                EmployeeId = Guid.NewGuid().ToString(),
                FirstName = "Jane",
                LastName = "Doe",
                Email = "janedoe@gmail.com",
                Address = "Lagos, Nigeria",
                PhoneNumber = "08145454760",
                CreatedAt = DateTime.Now,
                LastModifiedAt = DateTime.Now,
                IsActive = true
            },
            new Employee{
                EmployeeId = Guid.NewGuid().ToString(),
                FirstName = "Jonathan",
                LastName = "Kayode",
                Email = "jkayode@gmail.com",
                Address = "Los Angeles",
                PhoneNumber = "2339549390",
                CreatedAt = DateTime.Now,
                LastModifiedAt = DateTime.Now,
                IsActive = true
            },
            new Employee{
                EmployeeId = Guid.NewGuid().ToString(),
                FirstName = "Tolani",
                LastName = "Akinremi",
                Email = "tolakin@gmail.com",
                Address = "Ibadan, Nigeria",
                PhoneNumber = "09045239088",
                CreatedAt = DateTime.Now,
                LastModifiedAt = DateTime.Now,
                IsActive = true
            },
    };
        public AccountService()
        {

        }

        public async Task<ServiceResponse<Employee>> CreateAccountAsync(CreateAccountDto payload)
        {
            var serviceResponse = new ServiceResponse<Employee>();

            try
            {
                var recordExist = employees.Where(e => e.Email == payload.Email).FirstOrDefault(); //check if record exist
                if (recordExist != null)
                {
                    serviceResponse.Data = new Employee { };
                    serviceResponse.Message = "Record already exist";
                    serviceResponse.Success = false;
                    serviceResponse.StatusCode = (int)HttpStatusCode.Conflict;


                    return serviceResponse;
                }


                var newRecord = new Employee
                {
                    EmployeeId = Guid.NewGuid().ToString(),
                    FirstName = payload.FirstName,
                    LastName = payload.LastName,
                    Email = payload.Email,
                    Address = payload.Address,
                    PhoneNumber = payload.PhoneNumber,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    IsActive = true
                };

                employees.Add(newRecord); //add data
                                          //var result = accounts.ToList();//fetch data

                serviceResponse.Data = newRecord;
                serviceResponse.StatusCode = (int)HttpStatusCode.Created;
                serviceResponse.Message = "Record successfully created";
                serviceResponse.Success = true;

            }
            catch (Exception)
            {
                throw;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<Employee>>> GetAllRecords()
        {
            var serviceResponse = new ServiceResponse<List<Employee>>();
            try
            {
                var result = employees.ToList();

                if (result.Count > 0)
                {

                    serviceResponse.Data = result;
                    serviceResponse.StatusCode = (int)HttpStatusCode.OK; // or use 200
                    serviceResponse.Message = "Record successfully retrieved";
                    serviceResponse.Success = true;
                    return serviceResponse;

                }
                else
                {
                    serviceResponse.Data = new List<Employee>();

                    serviceResponse.Message = "No Record found";
                    serviceResponse.Success = false;
                    serviceResponse.StatusCode = (int)HttpStatusCode.NoContent;
                }

            }
            catch (Exception)
            {
                throw;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Employee>> UpdateAccountAsync(CreateAccountDto payload)
        {
            var serviceResponse = new ServiceResponse<Employee>();
            try
            { //update records
                var recordExist = employees.Where(e => e.Email == payload.Email).FirstOrDefault();
                if (recordExist == null)
                {
                    serviceResponse.Data = new Employee { };
                    serviceResponse.Message = "Record does not exist";
                    serviceResponse.Success = false;
                    serviceResponse.StatusCode = (int)HttpStatusCode.BadRequest; //400
                }

                recordExist.FirstName = payload.FirstName;
                recordExist.LastName = payload.LastName;
                recordExist.Email = payload.Email;
                recordExist.Address = payload.Address;

                employees.Add(recordExist); //add data
                                            //var result = accounts.ToList();//fetch data

                serviceResponse.Data = recordExist;
                serviceResponse.Message = "Record updated";
                serviceResponse.Success = true;
                serviceResponse.StatusCode = (int)HttpStatusCode.OK; //200

            }
            catch (Exception)
            {
                throw;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<Employee>> DeleteRecordById(string EmployeeId)
        {
            var serviceResponse = new ServiceResponse<Employee>();
            try
            {
                var recordExist = employees.Where(e => e.EmployeeId == EmployeeId).FirstOrDefault();
                if (recordExist == null)
                {
                    serviceResponse.Data = new Employee { };
                    serviceResponse.Message = "Record does not exist";
                    serviceResponse.Success = false;
                    serviceResponse.StatusCode = (int)HttpStatusCode.Conflict; //409
                }


                serviceResponse.Data = recordExist;
                serviceResponse.Message = "Record Successfully deleted";
                serviceResponse.Success = true;
                serviceResponse.StatusCode = (int)HttpStatusCode.Gone; //410

            }
            catch (Exception)
            {
                throw;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Employee>> GetRecordById(string EmployeeId)
        {
            var serviceResponse = new ServiceResponse<Employee>();
            try
            { //get recordbyID
                var recordExist = employees.Where(e => e.EmployeeId == EmployeeId).FirstOrDefault();
                if (recordExist == null)
                {
                    serviceResponse.Data = new Employee { };
                    serviceResponse.Message = "Record does not exist";
                    serviceResponse.Success = false;
                    serviceResponse.StatusCode = (int)HttpStatusCode.Conflict; //409

                }

                employees.Remove(recordExist);
                serviceResponse.Data = recordExist;
                serviceResponse.Message = "Record Successfully retrieved";
                serviceResponse.Success = true;
                serviceResponse.StatusCode = (int)HttpStatusCode.OK; //200


            }
            catch (Exception)
            {
                throw;
            }
            return serviceResponse;
        }

    }
 }
