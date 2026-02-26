using FIlmes.WebAPI.BdContextFilme;
using FIlmes.WebAPI.Interface;
using FIlmes.WebAPI.Repositories;
using FILmes.WebAPI.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o contexto do banco de dados(exemplo com SQl Server)

builder.Services.AddDbContext<FilmeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Adiciona o repositório ao container de injeção de dependência

builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//Adiciona serviço de Jwt Bearer (forma de autenticação)
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";

})
    .AddJwtBearer("JwtBearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //Valida quem está solicitado
            ValidateIssuer = true,
            //Valida quem está recebendo
            ValidateAudience = true,
            //Define se o tempo de expiraçõa será validado
            ValidateLifetime = true,
            //forma de criptogreafia  valida a chave de autenticação
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),
            //Valida o tempo de expiração do token
            ClockSkew = TimeSpan.FromMinutes(5),
            //Nome do issuer (de onde está vindo)
            ValidIssuer = "api_filmes",
            //Nome de audience (para onde ele está indo)
            ValidAudience = "api_filmes"
        };
    }
    );

//Adiciona o serviço de controllers

builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthentication();

app.UseAuthorization();

//ADICIONA O MAPEAMENTO DE CONTROLE
app.MapControllers();

app.Run();
