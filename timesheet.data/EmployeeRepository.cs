using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timesheet.common.Interfaces;
using timesheet.model;

namespace timesheet.data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TimesheetDb _db;
        public EmployeeRepository(TimesheetDb db)
        {
            _db = db;
        }

        public async Task<Employee> AddNewEmployee(Employee employee)
        {
            try
            {
                 _db.Employees.Add(employee);
                var insertStatus =  await _db.SaveChangesAsync();
                return employee;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _db.Employees.FirstOrDefaultAsync(x => x.Id == id);
                return employee;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
