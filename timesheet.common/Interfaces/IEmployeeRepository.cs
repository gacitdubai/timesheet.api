using timesheet.model;

namespace timesheet.common.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> AddNewEmployee(Employee employee);

    }
}
