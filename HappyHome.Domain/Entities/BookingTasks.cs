using HappyHome.Domain.Commons;
using HappyHome.Domain.Enums;

namespace HappyHome.Domain.Entities;

public class BookingTasks : Auditable
{
    public long BookingId { get; set; }
    public long TaskId { get; set; }
    public long EmployeeId { get; set; }
    public DateTime TaskDate { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public StatusType Status { get; set; }
}
