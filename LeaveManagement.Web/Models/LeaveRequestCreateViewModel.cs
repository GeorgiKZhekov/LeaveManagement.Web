﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models;

public class LeaveRequestCreateViewModel : IValidatableObject
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

    public SelectList? LeaveTypes { get; set; }

    [Display(Name = "Request comment")]
    public string? RequestsComments { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(StartDate > EndDate)
        {
            yield return new ValidationResult("The Start date must be before the End date!", new[] {nameof(StartDate), nameof(EndDate)});
        }
    }
}
