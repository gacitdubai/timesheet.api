using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timesheet.common.Dtos;
using timesheet.common.Interfaces;
using timesheet.comomon.Requests;
using timesheet.model;
namespace timesheet.data
{
    public class TaskRepository : ITaskRespository
    {
        private readonly TimesheetDb _db;

        public TaskRepository(TimesheetDb db)
        {
            _db = db;
        }

        public async Task<bool> AddNewEmployeeTask(EmployeeTasks request)
        {
            try
            {
                 await _db.EmployeeTasks.AddAsync(request);
                return await _db.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> AddNewTask(AddNewTaskRequest request)
        {
            try
            {


                return System.Threading.Tasks.Task.FromResult(false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<List<EffortReportDto>> GenerateEffortReportByMonth(int month, int year)
        {
            try
            {

                var sql = @"
                             SELECT 
                                 e.Id as EmployeeId, 
                                 e.Name as [EmployeeName],
                                 SUM(DATEDIFF(SECOND, t.StartTime, t.EndTime) / 3600.0) AS TotalHoursWorked
                             FROM EmployeeTasks t
                             INNER JOIN Employees e ON t.EmployeeId = e.Id
                             WHERE YEAR(t.StartTime) = @year AND MONTH(t.StartTime) = @month
                             GROUP BY e.Id, e.Name";

                var result = _db.Database.SqlQueryRaw<EffortReportDto>
                    (sql, new SqlParameter("@year", year), new SqlParameter("@month", month))
                    .ToList();

                return result;
            }
            catch (Exception w)
            {

                throw;
            }
        }

        public async Task<timesheet.model.Task> GetTaskById(int id)
        {
            try
            {
                return _db.Tasks.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<TaskDto>> Search(string searchToken)
        {
            try
            {
                var response = await _db.Tasks.Where(x => EF.Functions.Like(x.Name, $"%{searchToken}%"))
                    .Select(x => new TaskDto 
                    {
                        TaskId = x.Id,
                        TaskName = x.Name
                    })
                    .ToListAsync();
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
