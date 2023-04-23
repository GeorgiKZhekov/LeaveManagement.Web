using LeaveManagement.Web.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Web.Models;

public class LeaveRequestViewModel : LeaveRequestCreateViewModel
{ 
    public int Id { get; set; }

    [Display(Name = "Leave type")]
    public LeaveTypeViewModel LeaveType { get; set; }

    [Display(Name = "Date requested")]
    public DateTime DateRequested { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
    public string? RequestingEmployeeId { get; set; }
    public EmployeeViewModel Employee { get; set; }
}
