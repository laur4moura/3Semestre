using System;

public class Usuario : IAutenticavel
{
    public string Nome { get; set; }
    private string senha;

    public Usuario(string nome, string senha)
    {
        Nome = nome;
        this.senha = senha;
    }

    public bool Autenticar(string senha)
    {
        return this.senha == senha;
    }

    public void Exibir()
    {
        Console.WriteLine($"Usuário: {Nome}");
    }
}
