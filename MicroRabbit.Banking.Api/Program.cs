using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Info.Bus;
using MicroRabbit.IoC;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c=> 
                c.SwaggerDoc("v1",new Microsoft.OpenApi.Models.OpenApiInfo {Title = "Banking Microservice",Version = "v1" }));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

RegisterServices();

var app = builder.Build();
 

void RegisterServices()
{
    builder.Services.AddDbContext<BankingDbContext>(options => 
                                       options.UseSqlServer(builder.Configuration.GetConnectionString("BankingDbConnection")));

    DependencyContainer.RegisterServices(builder.Services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json","Banking Microservice V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
