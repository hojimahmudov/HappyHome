using HappyHome.Domain.Commons;

namespace HappyHome.Domain.Entities;

public class EmployeeAvailability : Auditable
{
    public DateTime AvailableDate { get; set; }
    public DateTime StartTime { get; set; } 
    public DateTime EndTime { get; set; }
}
