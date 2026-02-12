using System;

public class Administrador : IAutenticavel
{
    public string Nome { get; set; }
    private string senha;

    public Administrador(string nome, string senha)
    {
        Nome = nome;
        this.senha = senha;
    }

    public bool Autenticar(string senha)
    {
        // mesma lógica simples; poderia ter política diferente
        return this.senha == senha;
    }

    public void Exibir()
    {
        Console.WriteLine($"Administrador: {Nome}");
    }
}
