namespace Igor.Models;

public class Folha
{
    public int folhaId { get; set; }
    public double valor { get; set; }
    public int quantidade { get; set; }
    public int mes { get; set; }
    public int ano { get; set; }
    public double salarioBruto { get; set; } = 0;
    public double impostoIrrf { get; set; } = 0;
    public double impostoInss { get; set; } = 0;
    public double impostoFgts { get; set; } = 0;
    public double salarioLiquido { get; set; } = 0;
    public int funcionarioId { get; set; }
    public Funcionario? Funcionario { get; set; }
}
