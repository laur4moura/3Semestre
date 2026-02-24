using FIlmes.WebAPI.Repositories;
using FILmes.WebAPI.BdContextFilme;
using FILmes.WebAPI.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o contexto do banco de dados(exemplo com SQl Server)

builder.Services.AddDbContext<FilmeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Adiciona o repositório ao container de injeção de dependência

builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();

//Adiciona o serviço de controllers

builder.Services.AddControllers();

var app = builder.Build();

//ADICIONA O MAPEAMENTO DE CONTROLE
app.MapControllers();

app.Run();
