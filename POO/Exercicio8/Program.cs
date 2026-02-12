using System;

class Program
{
	static void Main()
	{
		var usuario = new Usuario("laura", "1234");
		Console.WriteLine($"Autenticação usuário (correta): {usuario.Autenticar("1234")}");
		Console.WriteLine($"Autenticação usuário (incorreta): {usuario.Autenticar("0000")}");

		var admin = new Administrador("admin", "root");
		Console.WriteLine($"Autenticação admin (correta): {admin.Autenticar("root")}");
		Console.WriteLine($"Autenticação admin (incorreta): {admin.Autenticar("nope")}");
	}
}
