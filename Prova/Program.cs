using AutoWrapper;
using FluentValidation.AspNetCore;
using Prova.Data.DTO.Request;
using Prova.Data.Repositories;
using Prova.DataManager;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ModelExampleRequest>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICadastrarUsuarioManager, CadastrarUsuarioManager>();
builder.Services.AddSingleton<ICadastrarNotaFiscalManager, CadastrarNotaFiscalManager>();
builder.Services.AddSingleton<ICadastrarRangeAprovacaoManager, CadastrarRangeAprovacaoManager>();
builder.Services.AddSingleton<IMongoRepository, MongoRepository>();

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

