using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using timesheet.common.Exceptions;
using timesheet.common.Interfaces;
using timesheet.common.Requests;
using timesheet.data;
using timesheet.model;

namespace timesheet.business
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Employee> AddNewEmployee(CreateEmployeeRequest request)
        {
            try
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));
                var employee = _mapper.Map<Employee>(request);
                var employeeCreationStatus = await _employeeRepository.AddNewEmployee(employee);
                return employee;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Fetches the employee by Id
        /// </summary>
        /// <param name="id">Id of the employee</param>
        /// <returns></returns>
        public async Task<Employee> GetEmployee(int id)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployeeById(id);
                if (employee is null)
                    throw new EmployeeNotFoundException();
                return employee;
            }
            catch (Exception)
            {
                // Logging part
                throw;
            }
        }
    }
}
