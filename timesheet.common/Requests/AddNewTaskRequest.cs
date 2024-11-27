using System;

namespace timesheet.comomon.Requests
{
    public record AddNewTaskRequest
    {
        public int EmployeeId { get; set; }
        public int TaskId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
