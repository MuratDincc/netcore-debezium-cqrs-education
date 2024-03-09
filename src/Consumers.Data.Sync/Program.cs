using System.Text.Json;
using Confluent.Kafka;
using Consumers.Data.Sync.Business.Abstracts;
using Consumers.Data.Sync.Business.Dto;
using Consumers.Data.Sync.Configuration;
using Consumers.Data.Sync.Enums;
using Consumers.Data.Sync.Extensions;
using Consumers.Data.Sync.Models;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = AppBuilder.InitApp();

        var kafkaSettings = serviceProvider.GetService<KafkaSettings>();

        var conf = new ConsumerConfig
        {
            GroupId = kafkaSettings.GroupId,
            BootstrapServers = kafkaSettings.Host,
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = false
        };

        using (var c = new ConsumerBuilder<Ignore, string>(conf).Build())
        {
            c.Subscribe(kafkaSettings.TopicName);

            CancellationTokenSource cts = new CancellationTokenSource();

            var newsBusiness = serviceProvider.GetService<INewsBusiness>();

            while (true)
            {
                var cr = c.Consume(cts.Token);

                if (string.IsNullOrWhiteSpace(cr.Value))
                {
                    c.Commit(cr);
                    continue;
                }

                var queueData = JsonSerializer.Deserialize<DebeziumPayload<NewsMessageModel>>(cr.Value);

                if (queueData == null || queueData.Op == DebeziumOperationType.Read)
                {
                    c.Commit(cr);
                    continue;
                }

                if (queueData.Op == DebeziumOperationType.Create && queueData.After != null)
                {
                    try
                    {
                        var result = await newsBusiness.Create(new ()
                        {
                            NewsId = queueData.After.Id,
                            Title = queueData.After.Title,
                            ShortDesc = queueData.After.ShortDesc,
                            LongDesc = queueData.After.LongDesc,
                            Published = queueData.After.Published,
                        });
                
                        if (!result)
                        {
                            Console.WriteLine($"INSERT - FAIL");
                            continue;
                        }
                
                        Console.WriteLine($"INSERT - OK");
                
                        c.Commit(cr);
                    }
                    catch (Exception insertEx)
                    {
                        Console.WriteLine($"INSERT - FAIL (EXCEPTION): {queueData.After.Id} ({insertEx.Message})");
                    }
                }
                
                if (queueData.Op == DebeziumOperationType.Update && queueData.After != null)
                {
                    try
                    {
                        var result = await newsBusiness.Update( queueData.After.Id,new UpdateNewsDto
                        {
                            Title = queueData.After.Title,
                            ShortDesc = queueData.After.ShortDesc,
                            LongDesc = queueData.After.LongDesc,
                            Published = queueData.After.Published,
                        });
                
                        if (!result)
                        {
                            Console.WriteLine($"UPDATE - FAIL");
                            continue;
                        }
                
                        Console.WriteLine($"UPDATE - OK");
                
                        c.Commit(cr);
                    }
                    catch (Exception updateEx)
                    {
                        Console.WriteLine($"UPDATE - FAIL (EXCEPTION): {queueData.After.Id} ({updateEx.Message})");
                    }
                }
                
                if (queueData.Op == DebeziumOperationType.Delete)
                {
                    await newsBusiness.Delete(queueData.After.Id);
                    
                    Console.WriteLine($"DELETE - OK");
                    c.Commit(cr);
                    continue;
                }
            }
        }
    }
}
