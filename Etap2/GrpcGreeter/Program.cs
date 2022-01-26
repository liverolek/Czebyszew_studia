using GrpcGreeter.Services;
using System;

int port = Int32.Parse(string.Join('-', args));
Console.WriteLine(port);

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options => options.ListenLocalhost(port));

// Add services to the container.
builder.Services.AddGrpc(options =>
    {
        options.EnableDetailedErrors = true;
        options.MaxReceiveMessageSize = 100 * 1024 * 1024; // 100 MB
        options.MaxSendMessageSize = 100 * 1024 * 1024; // 100 MB
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
