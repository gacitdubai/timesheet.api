using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timesheet.common.Dtos;
using timesheet.common.Exceptions;
using timesheet.common.Interfaces;
using timesheet.comomon.Requests;
using timesheet.model;

namespace timesheet.business
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRespository _taskRepository;
        private readonly IEmployeeService   _employeeService;
        private readonly IMapper _mapper;

        public TaskService(ITaskRespository taskRepository, IEmployeeService employeeService, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _employeeService = employeeService;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<EmployeeTimeEntry> AddNewTask(AddNewTaskRequest request)
        {

            try
            {
                if (request is null)
                {
                    throw new ArgumentNullException("CreateTimeEntryRequest cannot be null");
                }
                var selectedTask = await _taskRepository.GetTaskById(request.TaskId)
                var employee = await _employeeService.GetEmployee(request.EmployeeId);
                var employeeTask = _mapper.Map<EmployeeTasks>(request);
                var recordCreationStatus = await _taskRepository.AddNewEmployeeTask(employeeTask);
                if (recordCreationStatus)
                    throw new Exception("Unable to add the record");
                return new EmployeeTimeEntry
                {
                    TaskName = selectedTask.Name,
                    StartTime = request.StartTime.ToString(),
                    EndTime = request.EndTime.ToString()
                };

            }
            catch(InvalidTimeEntryException e)
            {
                 throw;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<List<EffortReportDto>> GetEffortMonthlyReport(int month, int year, int employeeId)
        {
            try
            {
                if (month == 0 || year == 0 || employeeId == 0)
                    throw new ArgumentException("Invalid values for month, year or employee id");

                var report = await _taskRepository.GenerateEffortReportByMonth(month, year);
                return report;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<EmployeeTimeEntry> AddTimeSheetEntry(AddNewTaskRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
