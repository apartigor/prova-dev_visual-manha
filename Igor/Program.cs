using Igor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Teste de API");

app.MapPost("funcionario/cadastrar", ([FromBody] Funcionario funcionario,
    [FromServices] AppDataContext bdd) =>
{
    bdd.Funcionarios.Add(funcionario);
    bdd.SaveChanges();
    return Results.Created("", funcionario);
});

app.MapGet("funcionario/listar", ([FromServices] AppDataContext bdd) =>
{
    if (bdd.Funcionarios.Any())
    {
        return Results.Ok(bdd.Funcionarios.ToList());
    }
    return Results.NotFound();
});

app.MapPost("folha/cadastrar", ([FromBody] Folha folha,
    [FromServices] AppDataContext bdd) =>
{
    bdd.Folhas.Add(folha);
    bdd.SaveChanges();
    return Results.Created("", folha);
});

app.MapGet("folha/listar", ([FromServices] AppDataContext bdd) =>
{
    if (bdd.Folhas.Any())
    {
        return Results.Ok(bdd.Folhas.ToList());
    }
    return Results.NotFound();
});

// app.MapGet("/folha/buscar/{cpf}/{mes}/{ano}", ([FromRoute] string cpf, int mes, int ano,
//     [FromServices] AppDataContext bdd) =>
// {
//     // Expressão lambda em C#
//     Folha? folha = bdd.Folhas.Find(folha.Funcionario.cpf, folha.Folha.mes, );
//     {
//         if (folha == null)
//         {
//             return Results.NotFound("Nenhuma folha encontrado!");
//         }
//     }
//     return Results.Ok(folha);
// });


app.Run();
