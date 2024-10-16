namespace Igor.Models;

public class Folha
{
    public int folhaId { get; set; }
    public decimal valor { get; set; }
    public int quantidade { get; set; }
    public int mes { get; set; }
    public int ano { get; set; }
    public decimal salarioBruto { get; set; } = 0;
    public decimal impostoIrrf { get; set; } = 0;
    public decimal impostoInss { get; set; } = 0;
    public decimal impostoFgts { get; set; } = 0;
    public decimal salarioLiquido { get; set; } = 0;
    public int funcionarioId { get; set; }
    public Funcionario? funcionario { get; set; }
}