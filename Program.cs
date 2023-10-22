using safemoney.API.Context;
using safemoney.API.Contracts;
using safemoney.API.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton<DbConnectionFactory>();
builder.Services.AddControllers();
builder.Services.AddScoped<IloginToken, LoginToken>();
builder.Services.AddScoped<DatabaseChecker>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Adicionando Logging
builder.Services.AddLogging(configure =>
{
    configure.AddConsole(); // Adiciona um provedor de logging para o Console
    // Outros provedores de logging podem ser adicionados aqui, como o Debug, etc.
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
      app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAll");

// Obtendo o Logger
var logger = app.Services.GetRequiredService<ILogger<Program>>();

// Exemplo de uso do Logger
logger.LogInformation("Aplicação iniciada.");

app.Run();
