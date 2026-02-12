using System;

class Program
{
	static void Main()
	{
		var pessoa = new Pessoa("Laura", 17);
		pessoa.ExibirDados();
		pessoa.Apresentar();
		pessoa.Apresentar("Anacleto");

		var funcionario = new Funcionario("Ana", 17, 1200.75m);
		funcionario.ExibirDados();
		funcionario.Apresentar();
		funcionario.Apresentar("Bezerra");
	}
}
