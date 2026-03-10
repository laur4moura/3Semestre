using EventPlus_.WebAPI.BdContextEvent;
using EventPlus_.WebAPI.Interface;
using EventPlus_.WebAPI.Repositories;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EventContext>(options =>
    options.UseSqlServer
    (builder.Configuration.GetConnectionString
    ("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Registrar as repositories (Injeção de dependência)
builder.Services.AddScoped<ITipoEventoRepository, TipoEventoRepository>();

//Adiciona Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API de Eventos",
        Description = "Aplicação para gerenciamento de eventos",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Laura Anacleto",
            Url = new Uri("https://www.linkedin.com/in/laura-anacleto-204752377")
        },
        License = new OpenApiLicense
        {
            Name = "Exemplo de Licena",
            Url = new Uri("https://examples.com/license")
        }
    });
    //usando a autenticação
    options.AddSecurityDefinition("Bearer", new
       OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token:"
    });

    options.AddSecurityRequirement(document => new
        OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer"
        , document)] = Array.Empty<string>().ToList()
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(options => { });
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
