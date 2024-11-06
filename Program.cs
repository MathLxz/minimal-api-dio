using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Interfaces;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrutura.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IServicoAdministrador, ServicoAdministrador>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContexto>( options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao"));
}
);
var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.MapPost("/login", ([FromBody] LoginDTO loginDTO, IServicoAdministrador servicoAdministrador) =>{
    
    if (servicoAdministrador.Login(loginDTO) != null)
        return Results.Ok("Login realizado com sucesso");

        else
            return Results.Unauthorized();
});

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

