using HealthTrakerAPI.Data;
using HealthTrakerAPI.Data.Contract;
using HealthTrakerAPI.Data.Implementation;
using HealthTrakerAPI.Services.Contract;
using HealthTrakerAPI.Services.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Db ConnectionString
builder.Services.AddDbContext<HealthTrackerContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add dependencies
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHealthDataRepository, HealthDataRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IHealthDataService, HealthDataService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

await app.RunAsync();
