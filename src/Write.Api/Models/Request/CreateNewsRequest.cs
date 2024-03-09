namespace Write.Api.Models.Request;

public class CreateNewsRequest
{
    public string Title { get; set; }
    public string ShortDesc { get; set; }
    public string LongDesc { get; set; }
    public bool Published { get; set; }
}