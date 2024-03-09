using Consumers.Data.Sync.Data.Abstracts;

namespace Consumers.Data.Sync.Entities;

public class News : BaseEntity
{
    public int NewsId { get; set; }
    public string Title { get; set; }
    public string ShortDesc { get; set; }
    public string LongDesc { get; set; }
    public bool Published { get; set; }
    public DateTimeOffset CreatedOnUtc { get; set; }
    public DateTimeOffset? UpdatedOnUtc { get; set; }
}