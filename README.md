# Projeto de Exemplo com .NET 7 e Kafka utilizando Schema Registry e Confluent

Este é um exemplo de projeto utilizando .NET 7 e Kafka, integrando-se com o Confluent Platform para gestão de esquemas (Schema Registry). O projeto inclui dois arquivos Docker Compose para facilitar a execução do ambiente Kafka.


## Pré-requisitos

- [Docker](https://docs.docker.com/get-docker/)
- [.NET 7](https://dotnet.microsoft.com/download/dotnet/7.0)

## Como Executar

1. Clone o repositório:

```bash
git clone https://github.com/seu-usuario/seu-projeto.git
cd seu-projeto
```
1. Execute o Docker Compose para o ambiente Kafka:
```
docker-compose -f docker/docker-compose.yaml up -d
docker-compose -f docker/docker-compose-confluent.yml up -d
```

## Detalhes do Ambiente Docker

### Kafka Brokers:

- `broker` (Confluent Kafka 7.5.0) - Portas: 9092 (PLAINTEXT), 9101 (JMX)
- `broker1` e `broker2` (Confluent Kafka 7.1.0) - Portas: 9094, 9095 (PLAINTEXT)

### Schema Registry:

- `schema-registry` (Confluent Schema Registry 7.5.0) - Porta: 8081

### Kafka Connect:

- `connect` (Confluent Connect 0.6.2-7.5.0) - Porta: 8083

### KSQLDB:

- `ksqldb-server` (Confluent KSQLDB 7.5.0) - Porta: 8088
- `ksqldb-cli` (Confluent KSQLDB CLI 7.5.0)

### Control Center:

- `control-center` (Confluent Control Center 7.5.0) - Porta: 9021

### Kafka REST Proxy:

- `rest-proxy` (Confluent Kafka REST Proxy 7.5.0) - Porta: 8082

### Zookeeper:

- `zookeeper` (Zookeeper 3.8) - Porta: 2181

## Observações

Certifique-se de que as portas necessárias (por exemplo, 9092, 8081) estão disponíveis.

## Referências

- [Confluent Platform](https://www.confluent.io/platform/)
- [Confluent Docker Images](https://docs.confluent.io/platform/current/installation/docker/docs/index.html)
- Curso de Kafka por Rafael

