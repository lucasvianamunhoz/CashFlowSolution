using Microsoft.Extensions.DependencyInjection;
using MediatR;
using ConsolidatedService.Queries;
using ConsolidatedService.Repositories;
using Microsoft.EntityFrameworkCore;
using ConsolidatedService.Data;
using ConsolidatedService.Models;
using Polly;
using Microsoft.Extensions.Http;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register the repository
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

// Register MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Register the IRequestHandler implementation explicitamente
builder.Services.AddTransient<IRequestHandler<GetDailyConsolidatedQuery, DailyConsolidated>, GetDailyConsolidatedQueryHandler>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Redis cache
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "redis:6379";
    options.InstanceName = builder.Environment.ApplicationName;
});

// Define the policies
var retryPolicy = Policy
    .Handle<HttpRequestException>()
    .OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
    .WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600));

var circuitBreakerPolicy = Policy
    .Handle<HttpRequestException>()
    .OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
    .CircuitBreakerAsync(2, TimeSpan.FromMinutes(1));

builder.Services.AddHttpClient("default")
    .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(retryPolicy))
    .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(circuitBreakerPolicy));

var app = builder.Build();

// Configure the HTTP request pipeline, if needed
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllers();

app.Run();
