using Confluent.Kafka;
using mic_bff_orchestator_api.Application.Ports.In;
using mic_bff_orchestator_api.Application.Ports.Out;
using mic_bff_orchestator_api.Application.UseCases;
using mic_bff_orchestator_api.Infrastructure.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddControllers();
builder.Services.AddScoped<ICreateEventUseCase, CreateEventUseCase>(); // UseCase

// Configuraci�n de Kafka
var kafkaProducerConfig = new ProducerConfig
{
    BootstrapServers = "192.168.0.140:9092"
};

// Registrar Producer
builder.Services.AddSingleton<IMessageProducer>(sp => new KafkaMessageProducer(kafkaProducerConfig)); 
// Registrar Use Case
builder.Services.AddScoped<ICreateEventUseCase, CreateEventUseCase>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:3000",
                "http://localhost:5173" // Vite
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // solo si usas cookies / auth
    });
});

// Controladores
builder.Services.AddControllers();

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowFrontend");
app.UseAuthorization();
//app.UseAuthentication();
app.MapControllers();
app.Run();
