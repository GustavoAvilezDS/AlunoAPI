using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AlunoAPI.Data;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AlunoAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AlunoAPIContext") ?? throw new InvalidOperationException("Connection string 'AlunoAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





builder.Services.AddCors( option =>
{
    option.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
}
    );




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
