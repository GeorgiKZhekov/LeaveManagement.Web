using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Contracts;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task CreateLeaveReequest(LeaveRequestCreateViewModel request);
    Task<EmployeeLeaveRequestViewModel> GetMyLeaveDetails();
}
