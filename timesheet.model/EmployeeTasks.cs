using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timesheet.model
{
    public class EmployeeTasks
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }  // Primary key with auto-increment (identity)

        public int EmployeeId { get; set; }  // Foreign key to Employee
        public int TaskId { get; set; }  // Foreign key to Task

        [Required]
        public DateTime StartTime { get; set; }  // Not nullable field
        [Required]
        public DateTime EndTime { get; set; }  // Not nullable field

        // Navigation properties (optional)
        public virtual Employee Employee { get; set; }
        public virtual Task Task { get; set; }
    }
}
