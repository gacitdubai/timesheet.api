using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timesheet.common.Requests;
using timesheet.model;

namespace timesheet.common.MappingProfiles
{
    public class EmployeeMappingProfile: Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<CreateEmployeeRequest, Employee>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.EmployeeCode))  
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.EmployeeName)); 
        }
    }
}
