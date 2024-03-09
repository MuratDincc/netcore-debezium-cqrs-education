# .NET Core Web Api CQRS - Kafka Debezium

In this project, .NET Core 8 is used, focusing on a scenario where read and write principles are completely separated. Kafka Debezium has been utilized for data consistency. This repo is the sample project for the .NET Core with CQRS training that we have uploaded on YouTube.

## Tech Stack

- .NET Core 8
- PostgreSQL
- MongoDB
- YARP
- Entity Framework Core
- Kafka Debezium
- CQRS

## Run with Docker

Start with Docker Compose

```bash
  docker compose up -d
```

## Access List

- PostgreSQL: 5432
- MongoDB: 27017
- Kafka: 9092-29092
- Kafka Connect: 8083
- Debezium UI: http://localhost:8083
- Kafka UI: http://localhost:8083
- Mongo UI: http://localhost:8081
- Gateway: http://localhost:5500
- Write Api: http://localhost:5501
- Read Api: http://localhost:5502

## YouTube

- [YouTube Channel](https://www.youtube.com/@muratdincc)
- [Course](https://www.youtube.com/@muratdincc)
