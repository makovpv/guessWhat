using DataStorage;
using DataStorage.Repos;
using WebApplicationApi;
using WebApplicationApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

//builder.Services.AddLogging();

builder.Services.AddSingleton<IPlaneRepository, PlaneRepository>();
builder.Services.AddSingleton<IAirportRepository, AirportRepository>();
builder.Services.AddSingleton<IAirportService, AirportService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	//app.UseSwagger();
	//app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.UseCors(builder => builder.AllowAnyOrigin());

app.UseMiddleware<MyMiddleware>();

app.MapControllers();

app.Run();
