using Igor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Teste de API");

app.MapPost("/api/funcionario/cadastrar", ([FromBody] Funcionario funcionario,
    [FromServices] AppDataContext bdd) =>
{
    bdd.Funcionarios.Add(funcionario);
    bdd.SaveChanges();
    return Results.Created("", funcionario);
});

app.MapGet("/api/funcionario/listar", ([FromServices] AppDataContext bdd) =>
{
    if (bdd.Funcionarios.Any())
    {
        return Results.Ok(bdd.Funcionarios.ToList());
    }
    return Results.NotFound();
});

app.MapPost("api/folha/cadastrar", ([FromBody] Folha folha, [FromServices] AppDataContext bdd) =>
{
    var funcionario = bdd.Funcionarios.Find(folha.funcionarioId);
    if (funcionario == null)
    {
        return Results.NotFound("Funcionário não encontrado!");
    }

    folha.salarioBruto = folha.quantidade * folha.valor;


    if (folha.salarioBruto < 1903.98m)
    {
        folha.impostoIrrf = 0;
    }
    else if (folha.salarioBruto >= 1903.98m && folha.salarioBruto < 2826.65m)
    {
        folha.impostoIrrf = folha.salarioBruto * 0.075m - 142.80m;
    }
    else if (folha.salarioBruto >= 2826.65m && folha.salarioBruto < 3751.05m)
    {
        folha.impostoIrrf = folha.salarioBruto * 0.15m - 354.8m;
    }
    else if (folha.salarioBruto >= 3751.05m && folha.salarioBruto < 4664.68m)
    {
        folha.impostoIrrf = folha.salarioBruto * 0.225m - 636.13m;
    }
    else
    {
        folha.impostoIrrf = folha.salarioBruto * 0.275m - 869.36m;
    }

    if (folha.salarioBruto < 1693.72m)
    {
        folha.impostoInss = folha.salarioBruto * 0.08m;
    }
    else if (folha.salarioBruto >= 1693.72m && folha.salarioBruto <= 2822.90m)
    {
        folha.impostoInss = folha.salarioBruto * 0.09m;
    }
    else if (folha.salarioBruto > 2822.90m && folha.salarioBruto <= 5645.80m)
    {
        folha.impostoInss = folha.salarioBruto * 0.11m;
    }
    else
    {
        folha.impostoInss = folha.salarioBruto - 621.03m;
    }

    folha.impostoFgts = folha.salarioBruto * 0.08m;
    folha.salarioLiquido = folha.salarioBruto - folha.impostoFgts - folha.impostoInss - folha.impostoIrrf;

    folha.funcionario = funcionario;
    bdd.Folhas.Add(folha);
    bdd.SaveChanges();

    return Results.Created("", folha);
});


app.MapGet("/api/folha/listar", ([FromServices] AppDataContext bdd) =>
{
    if (bdd.Folhas.Any())
    {
        return Results.Ok(bdd.Folhas.ToList());
    }
    return Results.NotFound();
});

app.MapGet("/api/folha/buscar/{cpf}/{mes}/{ano}", ([FromRoute] string cpf, int mes, int ano,
    [FromServices] AppDataContext bdd) =>
{
    //Expressão lambda em C#
    Folha? folha = bdd.Folhas.FirstOrDefault(f => cpf == cpf && f.mes == mes && f.ano == ano);
    {
        if (folha == null)
        {
            return Results.NotFound("Nenhuma folha encontrado!");
        }
    }
    return Results.Ok(folha);
});



app.Run();