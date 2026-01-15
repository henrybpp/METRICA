using Confluent.Kafka;
using mic_event_api.Application.Ports.In;
using mic_event_api.Application.Ports.Out;
using mic_event_api.Application.UseCases;
using mic_event_api.Infrastructure.Messaging;
using mic_event_api.Infrastructure.Persistence;
using mic_event_api.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IEventRepository, EventRepository>(); // Repositorio
builder.Services.AddScoped<ICreateEventUseCase, CreateEventUseCase>(); // UseCase

// Configuración de Kafka
var kafkaConfig = new ConsumerConfig
{
    BootstrapServers = "192.168.0.140:9092",
    GroupId = "events-consumer-group",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

// Inyección de dependencias
builder.Services.AddSingleton<IMessageConsumer>(sp =>new KafkaMessageConsumer("events-topic", kafkaConfig));

// Registrar el BackgroundService
builder.Services.AddHostedService<KafkaBackgroundService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
