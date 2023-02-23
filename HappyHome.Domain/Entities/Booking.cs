using HappyHome.Domain.Commons;
using HappyHome.Domain.Enums;

namespace HappyHome.Domain.Entities;

public class Booking : Auditable 
{ 
    public long CustomerId { get; set; }    
    public long ServiceId { get; set; }
    public DateTime BookingDate { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public StatusType Status { get; set; }
}
