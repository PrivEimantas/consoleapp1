using System.Reflection;
using FakeAPI.Core.V1.Mapper;
using FakeAPI.Core.V1.Models;
using FakeAPI.Core.V1.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
// using Microsoft.Extensions.Caching.StackExchangeRedis;
// using OpenTelemetry.Metr
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);
// builder.WebHost.AddDefaultListenerPorts();


builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<ITradeRepository, InMemoryTradeRepository>();
builder.Services.AddSingleton<IMapper,Mapper>();
// builder.Services.AddCoreDependencies();

var app = builder.Build();

// app.Configuration.PrintToConsole();


app.UseHttpsRedirection();


app.UseRouting();
// app.UseHttpMetrics();

app.Run();
