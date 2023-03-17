using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models;

public class EmployeeListViewModel
{
    public string Id { get; set; }
    [Display(Name = "First name")]
    public string FirstName { get; set; }
    [Display(Name = "Last name")]
    public string LastName { get; set; }
    [Display(Name = "Email address")]
    public string Email { get; set; }
    [Display(Name = "Date joined")]
    public DateTime DateJoined { get; set; }
}
