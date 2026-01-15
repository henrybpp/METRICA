using Confluent.Kafka;
using mic_notification_api.Application.Ports.In;
using mic_notification_api.Application.Ports.Out;
using mic_notification_api.Application.UseCases;
using mic_notification_api.Infrastructure.Messaging;
using mic_notification_api.Infrastructure.Persistence;
using mic_notification_api.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<INotificationRepository, NotificationRepository>(); // Repositorio
builder.Services.AddScoped<INotificationUseCase, NotificationUseCase>(); // UseCase

// Configuraci�n de Kafka
var kafkaConfig = new ConsumerConfig
{
    BootstrapServers = "192.168.0.140:9092",
    GroupId = "notifications-consumer-group",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

// Inyecci�n de dependencias
builder.Services.AddSingleton<IMessageConsumer>(sp =>new KafkaMessageConsumer("notifications-topic", kafkaConfig));

// Registrar el BackgroundService
builder.Services.AddHostedService<KafkaBackgroundService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
