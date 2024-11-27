using System.Collections.Generic;
using System.Threading.Tasks;
using timesheet.common.Dtos;
using timesheet.comomon.Requests;

namespace timesheet.common.Interfaces
{
    public interface ITaskService
    {
        Task<EmployeeTimeEntry> AddNewTask(AddNewTaskRequest request);

        Task<List<EffortReportDto>> GetEffortMonthlyReport(int month, int year, int employeeId);
    }
}
