using Microsoft.EntityFrameworkCore;
using MovieReservation.Infrastructure.Context;
using MovieReservationBackend.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<MovieReservationContext>(options => options.UseNpgsql(connectionString, providerOptions => providerOptions.EnableRetryOnFailure()).UseSnakeCaseNamingConvention());


builder.Services.ConfigureDependencies(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
