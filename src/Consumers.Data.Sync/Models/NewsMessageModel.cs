using System.Text.Json.Serialization;

namespace Consumers.Data.Sync.Models;

public class NewsMessageModel
{
    [JsonPropertyName("Id")]
    public int Id { get; set; }

    [JsonPropertyName("Title")]
    public string Title { get; set; }

    [JsonPropertyName("ShortDesc")]
    public string ShortDesc { get; set; }
    
    [JsonPropertyName("LongDesc")]
    public string LongDesc { get; set; }

    [JsonPropertyName("Published")]
    public bool Published { get; set; }
}
