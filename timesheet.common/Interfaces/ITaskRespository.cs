using timesheet.common.Dtos;
using timesheet.comomon.Requests;
using timesheet.model;

namespace timesheet.common.Interfaces
{
    public interface ITaskRespository
    {

        Task<timesheet.model.Task> GetTaskById(int id);
        Task<bool> AddNewTask(AddNewTaskRequest request);
        Task<bool> AddNewEmployeeTask(EmployeeTasks request);

        Task<timesheet.model.Task> GetTaskById(int id);

        Task<List<EffortReportDto>> GenerateEffortReportByMonth(int month, int year);
    }
}
