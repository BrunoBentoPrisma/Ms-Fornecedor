using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using MsFornecedor.MsContext;
using MsFornecedor.RabbitMq;
using MsFornecedor.RabbitMqClient.Intefaces;
using MsFornecedor.RabbitMqClient.RabbitMqClient;
using MsFornecedor.Repositorys.Interfaces;
using MsFornecedor.Repositorys.Repository;
using MsFornecedor.Services.Interfaces;
using MsFornecedor.Services.Service;
using MsFornecedor.Validations.Interfaces;
using MsFornecedor.Validations.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MsFornecedorContext>(opt => opt.UseNpgsql(connectionString));

builder.Services.AddSingleton<IRepositoryFornecedor, RepositoryFornecedor>();
builder.Services.AddScoped<IRepositoryBairro, RepositoryBairro>();

builder.Services.AddScoped<IFornecedorService, FornecedorService>();
builder.Services.AddHostedService<ProcessMessageConsumer>();
builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection("RabbitMqConfig"));

builder.Services.AddSingleton<IRabbitMqConsumerBairro, RabbitMqConsumerBairro>();

builder.Services.AddSingleton<IFornecedorValidations, FornecedorValidations>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Mypolicy",
                      policy =>
                      {
                          policy.WithOrigins()
                            .WithHeaders(
                                    HeaderNames.ContentType,
                                    HeaderNames.Authorization)
                            .AllowAnyMethod()
                            .AllowCredentials();
                      });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
