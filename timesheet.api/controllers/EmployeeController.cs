using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using timesheet.business;
using timesheet.common.Interfaces;
using timesheet.common.Requests;

namespace timesheet.api.controllers
{
    [Route("api/v1/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ITaskService _taskService;
        public EmployeeController(IEmployeeService employeeService, ITaskService taskService)
        {
            _employeeService = employeeService;
            _taskService = taskService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll(string text)
        {
            var items = _employeeService.GetEmployee(1);
            return new ObjectResult(items);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeRequest request)
        {
            var validator = HttpContext.RequestServices.GetRequiredService<IValidator<CreateEmployeeRequest>>();
            if (validator is null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to fetch the validators");
            var createdEmployee = await _employeeService.AddNewEmployee(request);
            return Ok(createdEmployee);
        }

        [HttpGet("GenerateMonthlyReport")]
        public async Task<IActionResult> GenerateMonthlyReport(int month, int year)
        {
            if (month == 0 || year == 0)
                return BadRequest("Both month and year is required for generating the report");

            // Hardcoding the manager empid here, assuming we can extract the RBAC info from the payload of ID token or access token
            var report = await _taskService.GetEffortMonthlyReport(month, year, 5);
            return Ok(report);
        }
    }
}