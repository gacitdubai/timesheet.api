using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timesheet.common.Requests;
using timesheet.model;

namespace timesheet.common.Interfaces
{
    public interface IEmployeeService
    {
        public Task<Employee> GetEmployee(int id);
        public Task<Employee> AddNewEmployee(CreateEmployeeRequest request);
    }
}
