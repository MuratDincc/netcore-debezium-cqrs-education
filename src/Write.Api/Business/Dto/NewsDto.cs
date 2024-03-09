namespace Write.Api.Business.Dto;

public record NewsDto
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string ShortDesc { get; init; }
    public string LongDesc { get; init; }
    public bool Published { get; init; }
}