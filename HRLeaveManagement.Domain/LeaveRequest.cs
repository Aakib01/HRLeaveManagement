// Ignore Spelling: Cancelled

using HRLeaveManagement.Domain.common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRLeaveManagement.Domain;

public class LeaveRequest : BaseEntity
{
    public LeaveType? LeaveType { get; set; }

    public int LeaveTypeId { get; set; }

    public bool? Approved { get; set; }

    public bool Cancelled { get; set; }

    public DateTime DateRequested {  get; set; }

    public string? RequestComments { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string RequestingEmployeeId { get; set; }

}
