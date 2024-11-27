using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timesheet.comomon.Requests;

namespace timesheet.common.Validators
{
    public class AddNewTaskValidator: AbstractValidator<AddNewTaskRequest>
    {
        public AddNewTaskValidator()
        {
            RuleFor(x => x.EmployeeId)
                .NotNull()
                .NotEmpty()
                .NotEqual(0).WithMessage("Employee Id is required");
            RuleFor(x => x.TaskId)
                .NotNull()
                .NotEmpty()
                .NotEqual(0).WithMessage("Task Id is required");

            RuleFor(x => x.StartTime)
                .NotNull().WithMessage("Start time is required.")
                .NotEmpty().WithMessage("Start time cannot be empty.")
                .Must(WithinAllowedDateRange)
                .WithMessage("Start time must be within the past month and not in the future.");

            RuleFor(x => x.StartTime)
               .NotNull().WithMessage("Date is required.")
               .NotEmpty().WithMessage("Date cannot be empty.")
               .GreaterThanOrEqualTo(x => x.StartTime).WithMessage("End time should always be greater than start time");

        }

        private bool WithinAllowedDateRange(DateTime startTime)
        {
            var currentDate = DateTime.UtcNow.Date;
            var oneMonthAgo = currentDate.AddMonths(-1);
            return startTime.Date >= oneMonthAgo && startTime.Date <= currentDate;
        }
    }
}
