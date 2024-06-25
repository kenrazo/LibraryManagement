using LibraryManagement.API;
using LibraryManagement.Application;
using LibraryManagement.Infrastructure.EFCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddAPIConfiguration()
    .AddInfrastructureEFCoreConfiguration()
    .AddApplicationConfiguration();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
SampleData.Initialize(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();
app.AddEndpoints();
app.Run();

