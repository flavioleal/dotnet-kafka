using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;

var schemaConfig = new SchemaRegistryConfig()
{
    Url = "http://localhost:8081"
};

var schemaRegistry = new CachedSchemaRegistryClient(schemaConfig);

var config = new ConsumerConfig
{
    GroupId = "dkexample",
    BootstrapServers = "localhost:9092"
};

using var consumer = new ConsumerBuilder<string, kafka.exemplo.Curso>(config)
 .SetValueDeserializer(new AvroDeserializer<kafka.exemplo.Curso>(schemaRegistry).AsSyncOverAsync())
 .Build();

consumer.Subscribe("cursos");

while (true)
{
    var result = consumer.Consume();
    System.Console.WriteLine($"Mensagem: {result.Message.Value.Descricao}");
}