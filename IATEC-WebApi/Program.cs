using Microsoft.EntityFrameworkCore;
using IATEC_desafio.Common.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// BD em memória, pra testes
builder.Services.AddDbContext<IATECContext>(options =>
    options.UseInMemoryDatabase("IATECDB")
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.UsePathBase(new PathString("/api-docs/index.html"));

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger( config =>
        {
            config.RouteTemplate = "api-docs/{documentname}/swagger.json";
        }
    );
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/api-docs/v1/swagger.json", "v1");
        options.RoutePrefix = "api-docs";
    });
//}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
