

using Microsoft.EntityFrameworkCore;
using ConnectPLus.BdContextConnectPlus;
using ConnectPLus.Interface;
using ConnectPLus.Repositories;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
     




       

        // 1. Configurar o Contexto do Banco de Dados
        builder.Services.AddDbContext<ConnectPlusContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        //2. Registrar as Repositories (Injeção de Dependência)
        builder.Services.AddScoped<ITipoContatoRepository, TipoContatoRepository>();
        builder.Services.AddScoped<IContatoRepository, ContatoRepository>();


        //Adiciona Swagger
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = "JwtBearer";
            options.DefaultChallengeScheme = "JwtBearer";
        })

        .AddJwtBearer("JwtBearer", options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {

                //Valida quem esta solicitando
                ValidateIssuer = true,

                //Valida quem esta recebendo
                ValidateAudience = true,

                //Define se o tempo de expiração do token deve ser validado
                ValidateLifetime = true,

                //Forma de cripotrografia e valida a chave de autenticacao
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("event+-chave-autenticacao-webapi-dev")),

                //Valida o tempo de expiração do token
                ClockSkew = TimeSpan.FromMinutes(5),

                //Nome do issuer (de onde esta vindo)
                ValidIssuer = "api_eventplus",

                //Nome do audience (para onde vai)
                ValidAudience = "api_eventplus"
            };
        });

        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Api de Eventos",
                Description = "Aplicação para gerenciamento de eventos",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Laura Anacleto",
                    Url = new Uri("https://www.linkedin.com/in/marcaumdev")
                },
                License = new OpenApiLicense
                {
                    Name = "Licensa de Exemplo",
                    Url = new Uri("https://example.com/license")
                }
            });

            //Usando a autenticação no Swagger
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Insira o token JWT:"
            });

            options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference("Bearer", document)] = Array.Empty<string>().ToList()
            });
        });

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

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

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

      

app.Run();
    }
}