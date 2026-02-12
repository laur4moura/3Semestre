using System;

public class Pessoa
{
    public string Nome { get; set; }

    private int idade;
    public int Idade
    {
        get => idade;
        set
        {
            if (value > 0)
            {
                idade = value;
            }
        }
    }

    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }

    public virtual void ExibirDados()
    {
        Console.WriteLine($"Nome: {Nome}, Idade: {Idade}");
    }

    public void Apresentar()
    {
        Console.WriteLine(Nome);
    }

    public void Apresentar(string sobrenome)
    {
        Console.WriteLine($"{Nome} {sobrenome}");
    }
}
