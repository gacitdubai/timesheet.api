using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using timesheet.common.Interfaces;
using timesheet.comomon.Requests;

namespace timesheet.api.controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskController: ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost("AddNewTask")]
        public async Task<IActionResult> AddNewTask([FromBody] AddNewTaskRequest request)
        {
            var validator = HttpContext.RequestServices.GetRequiredService<IValidator<AddNewTaskRequest>>();
            if (validator is null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to fetch the validators");
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var newTaskCreateResponse  = await _taskService.AddNewTask(request);
            return Ok(newTaskCreateResponse);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> GetTasks([FromQuery] string searchToken)
        {
            if (string.IsNullOrWhiteSpace(searchToken))
            {
                return BadRequest("Search token is empty");
            }

            return Ok(await _taskService.Search(searchToken));
        }


    }
}
