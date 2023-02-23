using HappyHome.Domain.Commons;

namespace HappyHome.Domain.Entities;

public class Servises : Auditable
{
    public string ServiceName { get; set; }
    public string Description { get; set; }
    public long Price { get; set; }
}
