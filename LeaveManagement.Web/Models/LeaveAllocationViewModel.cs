namespace LeaveManagement.Web.Models;

public class LeaveAllocationViewModel
{
    public int NumberOfDayse { get; set; }
    public int Period { get; set; }
    public LeaveTypeViewModel LeaveType { get; set; }
}