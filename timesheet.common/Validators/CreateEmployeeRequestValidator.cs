using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timesheet.common.Requests;

namespace timesheet.common.Validators
{
    public class CreateEmployeeRequestValidator: AbstractValidator<CreateEmployeeRequest>
    {
        public CreateEmployeeRequestValidator()
        {
            RuleFor(x => x.EmployeeCode)
                .NotEmpty().WithMessage("Employee code is required")
                .MaximumLength(10).WithMessage("Employee code cannot exceed 10 characters");
            RuleFor(x => x.EmployeeName)
                .NotEmpty().WithMessage("Employee Name is required")
                .MaximumLength(255).WithMessage("Employee Name cannot exceed 255 characters");
        }
    }
}
