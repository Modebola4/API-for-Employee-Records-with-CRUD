using EmployeeRecord.DTOs;
using EmployeeRecord.Interface;
using EmployeeRecord.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeRecord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("CreateAccount")]
        public async Task<IActionResult> CreateAccount([FromBody]CreateAccountDto payload)
        {
            var response = await _accountService.CreateAccountAsync(payload);

            if (response.StatusCode == (int)HttpStatusCode.OK)
            {
                return StatusCode(response.StatusCode, response);
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("GetAllRecords")]
        public async Task<IActionResult> GetAllRecords()
        {
            var response = await _accountService.GetAllRecords();
            if (response.StatusCode == (int)HttpStatusCode.OK) 
            {
                return StatusCode(response.StatusCode, response);
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("GetRecordById/EmployeeId")]
        public async Task<IActionResult> GetRecordById(string EmployeeId)
        {
            var response = await _accountService.GetRecordById(EmployeeId);

            if (response.StatusCode == (int)HttpStatusCode.OK)
            {
                return StatusCode(response.StatusCode, response);
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("UpdateAccount")]
        public async Task<IActionResult> UpdateAccountAsync([FromBody] CreateAccountDto payload)
        {
            var response = await _accountService.UpdateAccountAsync(payload);

            if (response.StatusCode == (int)HttpStatusCode.OK)
            {
                return StatusCode(response.StatusCode, response);
            }

            return StatusCode(response.StatusCode, response);
        }


        [HttpDelete("DeleteRecordById/EmployeeId")]
        public async Task<IActionResult> DeleteRecordById(string EmployeeId)
        {
            var response = await _accountService.DeleteRecordById(EmployeeId);

            if (response.StatusCode == (int)HttpStatusCode.OK)
            {
                return StatusCode(response.StatusCode, response);
            }

            return StatusCode(response.StatusCode, response);
        }

  

    }
}
