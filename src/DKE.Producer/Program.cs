using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;

var schemaConfig = new SchemaRegistryConfig()
{
    Url = "http://localhost:8081"
};

var schemaRegistry = new CachedSchemaRegistryClient(schemaConfig);

var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

using var producer = new ProducerBuilder<string, kafka.exemplo.Curso>(config)
    .SetValueSerializer(new AvroSerializer<kafka.exemplo.Curso>(schemaRegistry))
    .Build();

var message = new Message<string, kafka.exemplo.Curso>
{
    Key = Guid.NewGuid().ToString(),
    Value =  new kafka.exemplo.Curso {
        Id = Guid.NewGuid().ToString(),
        Descricao = $"Mensagem de teste {DateTime.Now.Second}",
    }
};

var result = await producer.ProduceAsync("cursos", message);

System.Console.WriteLine($"{result.Offset}");