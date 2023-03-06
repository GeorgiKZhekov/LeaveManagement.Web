using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models;

public class LeaveTypeViewModel
{
    public int Id { get; set; }

    [Display(Name = "Leave type name")]
    [Required]
    public string Name { get; set; }

    [Display(Name = "Default number of days")]
    [Required]
    [Range(1, 25, ErrorMessage = "Default days should be anywhere between 1 and 25.")]
    public int DefaultDays { get; set; }
}
