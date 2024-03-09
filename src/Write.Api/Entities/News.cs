namespace Write.Api.Entities;

public class News
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ShortDesc { get; set; }
    public string LongDesc { get; set; }
    public bool Published { get; set; }
    public DateTimeOffset CreatedOnUtc { get; set; }
    public DateTimeOffset? UpdatedOnUtc { get; set; }
}