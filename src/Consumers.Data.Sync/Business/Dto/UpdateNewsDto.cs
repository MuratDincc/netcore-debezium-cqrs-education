namespace Consumers.Data.Sync.Business.Dto;

public record UpdateNewsDto
{
    public string Title { get; init; }
    public string ShortDesc { get; init; }
    public string LongDesc { get; init; }
    public bool Published { get; init; }
}