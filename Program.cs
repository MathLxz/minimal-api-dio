using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.DTOs;
using minimal_api.Infraestrutura.Db;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbContexto>( options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao"));
}
);
var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (LoginDTO loginDTO) =>{
    if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha=="12345")
        return Results.Ok("Login realizado com sucesso");

        else
            return Results.Unauthorized();
});

app.Run();

