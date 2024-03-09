namespace Consumers.Data.Sync.Configuration;

public class KafkaSettings
{
    public string Host { get; set; }
    public string GroupId { get; set; }
    public string TopicName { get; set; }
}