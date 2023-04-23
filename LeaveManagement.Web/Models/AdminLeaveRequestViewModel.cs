using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class AdminLeaveRequestViewModel
    {
        [Display(Name = "Total numbers of requests")]
        public int TotalRequests { get; set; }
        [Display(Name = "Approved requests")]
        public int ApprovedRequests { get; set; }
        [Display(Name = "Pending requests")]
        public int PendingRequests { get; set; }
        [Display(Name = "Rejected requests")]
        public int RejectedRequests { get; set; }
        public List<LeaveRequestViewModel> LeaveRequests { get; set; }
    }
}
