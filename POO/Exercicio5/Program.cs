using System;

class Program
{
	static void Main()
	{
		var pessoa = new Pessoa("Laura", 17);
		pessoa.ExibirDados();

		var funcionario = new Funcionario("Larissa", 22, 2200.50m);
		funcionario.ExibirDados();
	}
}
