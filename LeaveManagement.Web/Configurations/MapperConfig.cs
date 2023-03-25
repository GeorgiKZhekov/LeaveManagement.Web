using AutoMapper;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<LeaveType, LeaveTypeViewModel>().ReverseMap();
        CreateMap<Employee, EmployeeViewModel>().ReverseMap();
        CreateMap<Employee, EmployeeAllocationsViewModel>().ReverseMap();
        CreateMap<LeaveAllocation, LeaveAllocationViewModel>().ReverseMap();
        CreateMap<LeaveAllocation, LeaveAllocationEditViewModel>().ReverseMap();
    }
    
}
