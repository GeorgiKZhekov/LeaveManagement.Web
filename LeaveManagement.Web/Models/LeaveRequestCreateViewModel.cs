using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models;

public class LeaveRequestCreateViewModel
{
    [Required]
    [Display(Name = "Start date")]
    public DateTime? StartDate { get; set; }

    [Required]
    [Display(Name = "End date")]
    public DateTime? EndDate { get; set; }
    
    [Required]
    [Display(Name = "Leave type")]
    public int LeaveTypeId { get; set; }

    public SelectList LeaveTypes { get; set; }

    [Display(Name = "Request comment")]
    public string RequestsComments { get; set; }

}
