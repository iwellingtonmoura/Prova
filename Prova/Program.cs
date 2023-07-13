using AutoWrapper;
using FluentValidation.AspNetCore;
using Prova.DataManager;
using Prova.Extensions;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ModelExampleRequest>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Adicionando a classe que injeta os serviços.
builder.Services.AddProvaWorker(builder.Configuration);

builder.Services.AddMemoryCache();

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

app.UseSwaggerUI();
app.UseAuthorization();
app.UseAuthentication();
app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions { IsDebug = true });

app.MapControllers();

app.Run();

