using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Contracts;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task CreateLeaveReequest(LeaveRequestCreateViewModel request);
    Task<EmployeeLeaveRequestViewModel> GetMyLeaveDetails();
    Task<AdminLeaveRequestViewModel> GetAdminLeaveRequestsList();
    Task ChangeApprovalStatus(int leaveRequestId, bool approvalStatus);
    Task<LeaveRequestViewModel> GetLeaveRequestsDetails(int id);
}
