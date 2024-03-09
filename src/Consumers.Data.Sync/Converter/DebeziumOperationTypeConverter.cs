using System.Text.Json;
using System.Text.Json.Serialization;
using Consumers.Data.Sync.Enums;

namespace Consumers.Data.Sync.Converter;

public class DebeziumOperationTypeConverter : JsonConverter<DebeziumOperationType>
{
    public override bool CanConvert(Type t) => t == typeof(DebeziumOperationType);

    public override DebeziumOperationType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();

        switch (value)
        {
            case "r":
                return DebeziumOperationType.Read;
            case "c":
                return DebeziumOperationType.Create;
            case "u":
                return DebeziumOperationType.Update;
            case "d":
                return DebeziumOperationType.Delete;
            default:
                return DebeziumOperationType.Empty;
        }

        throw new Exception("Cannot unmarshal type CardProgram");
    }

    public override void Write(Utf8JsonWriter writer, DebeziumOperationType value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case DebeziumOperationType.Create:
                JsonSerializer.Serialize(writer, "c", options);
                return;
            case DebeziumOperationType.Update:
                JsonSerializer.Serialize(writer, "u", options);
                return;
            case DebeziumOperationType.Delete:
                JsonSerializer.Serialize(writer, "d", options);
                return;
            default:
                JsonSerializer.Serialize(writer, "", options);
                return;
        }

        throw new Exception("Cannot marshal type Debezium Operation Type");
    }

    public static readonly DebeziumOperationTypeConverter Singleton = new DebeziumOperationTypeConverter();
}
