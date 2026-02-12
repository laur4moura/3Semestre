using System;

public class Funcionario : Pessoa
{
    public decimal Salario { get; set; }

    public Funcionario(string nome, int idade, decimal salario)
        : base(nome, idade)
    {
        Salario = salario;
    }

    public override void ExibirDados()
    {
        base.ExibirDados();
        Console.WriteLine($"Salário: {Salario}");
    }
}
