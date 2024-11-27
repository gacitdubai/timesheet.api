using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timesheet.common.Requests;
using timesheet.comomon.Requests;
using timesheet.model;

namespace timesheet.common.MappingProfiles
{
    public class TaskMappingProfile: Profile
    {
        public TaskMappingProfile()
        {
            CreateMap<AddNewTaskRequest, EmployeeTasks>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime));
        }
    }
}
