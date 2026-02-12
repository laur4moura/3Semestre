using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("Somar 2 + 3 = " + Calculadora.Somar(2, 3));
		Console.WriteLine("Somar múltiplos = " + Calculadora.Somar(1, 2, 3, 4));

		Console.WriteLine("Multiplicar 4 * 5 = " + Calculadora.Multiplicar(4, 5));
		Console.WriteLine("Multiplicar múltiplos = " + Calculadora.Multiplicar(2, 3, 4));
	}
}

