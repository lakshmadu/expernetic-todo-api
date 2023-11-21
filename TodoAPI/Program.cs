using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TodoAPI.Common;
using TodoAPI.DataAccess;
using TodoAPI.Mappers;
using TodoAPI.Services.TaskItems;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<TodoDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("Connection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITaskRepository, TaskSqliteRepository>();
builder.Services.AddScoped(typeof(TaskRelatedMapper));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var allowedOrigins = GetAllowedOrigins();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins(allowedOrigins)
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Test")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();


string[] GetAllowedOrigins()
{
    var origins = builder.Configuration.GetSection("AllowedOrigins").Value;

    if (!string.IsNullOrEmpty(origins))
    {
        var splittedOrigins = origins.Split(",");
        return splittedOrigins;
    }

    return null;
}
