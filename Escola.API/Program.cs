using Escola.Application;
using Escola.Domain.Interfaces.Applications;
using Escola.Domain.Interfaces.Repositories;
using Escola.Infrastructure.Data;
using Escola.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAlunoApplication, AlunoApplication>();
builder.Services.AddTransient<IAlunoRepository, AlunoRepository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
