using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timesheet.common.Requests
{
    public record CreateEmployeeRequest
    {
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
    }
}
