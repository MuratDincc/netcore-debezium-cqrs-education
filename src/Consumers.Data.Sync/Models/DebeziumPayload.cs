using System.Text.Json.Serialization;
using Consumers.Data.Sync.Converter;
using Consumers.Data.Sync.Enums;

namespace Consumers.Data.Sync.Models;

public class DebeziumPayload<T>
{
    [JsonPropertyName("before")]
    public T Before { get; set; }

    [JsonPropertyName("after")]
    public T After { get; set; }

    [JsonConverter(typeof(DebeziumOperationTypeConverter))]
    [JsonPropertyName("op")]
    public DebeziumOperationType Op { get; set; }
}
