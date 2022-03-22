using FileSystem.Core.Interfaces;
using FileSystem.GrpcServer.Services;
using FileSystem.Infrastructure;
using FileSystem.API;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();



string connectionString = builder.Configuration.GetConnectionString("SQLServer");
builder.Services.RegisterInfrastructureServices(connectionString);

builder.Services.AddScoped<IFileServerAPIService, FileServerAPIService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<FileServerService>().RequireHost("*:5001");
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
