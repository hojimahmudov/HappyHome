using HappyHome.Domain.Commons;

namespace HappyHome.Domain.Entities;

public class Tasks : Auditable
{
    public string TaskName { get; set; }
    public string Description { get; set; }
}
