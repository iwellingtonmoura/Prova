    using System.Text.Json;
    using AutoWrapper;
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.WebUtilities;
    using Prova.DataManager;
    using Prova.Extensions;
    using Microsoft.AspNetCore.Diagnostics.HealthChecks;
    using Microsoft.Extensions.Diagnostics.HealthChecks;
using Prova.Services;

var builder = WebApplication.CreateBuilder(args);



    // Add services to the container.

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    //Adicionando a classe que injeta os serviços.
    builder.Services.AddProvaWorker(builder.Configuration);
    builder.Services.AddHealthChecks();
    builder.Services.AddSingleton<ICacheRedis, CacheRedisService>();
    builder.Services.AddStackExchangeRedisCache(option => option.Configuration = builder.Configuration.GetConnectionString("Redis"));

    //builder.Services.AddMemoryCache();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    //if (app.Environment.IsDevelopment())
    //{
    //   app.UseSwagger();

    //}

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Aplicacao de Teste v1");
        options.DisplayRequestDuration();
    });


    app.UseHealthChecks("/status",
        new HealthCheckOptions()
        {
            ResponseWriter = (context, report) =>
            {
                var result = JsonSerializer.Serialize(
                    new
                    {
                        currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        statusApplication = report.Status.ToString(),
                        HealthChecks = report.Entries.Select(s => new
                        {
                            check = s.Key,

                            status = Enum.GetName(typeof(HealthStatus), s.Value.Status)
                        })
                    });
                return Task.CompletedTask;
            }
        });

    app.UseSwaggerUI();
    app.UseAuthorization();
    app.UseAuthentication();
    app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions { IsDebug = true });
    app.MapControllers();
    app.Run();

