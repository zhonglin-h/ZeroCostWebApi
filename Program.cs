using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using testWebAPI.Data;
using testWebAPI.Repository;
using testWebAPI.Repository.Contract;
using testWebAPI.Service;
using testWebAPI.Service.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(Environment.GetEnvironmentVariable("CUSTOMCONNSTR_PostgresDb"));
    options.UseSnakeCaseNamingConvention();
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// inject layers
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetWebApiSeriesCore5", Version = "v1" });
    });

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
