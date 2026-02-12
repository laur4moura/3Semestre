using System;

public static class Calculadora
{
    public static double Somar(params double[] valores)
    {
        double soma = 0;
        foreach (var v in valores)
            soma += v;
        return soma;
    }

    public static double Multiplicar(params double[] valores)
    {
        if (valores == null || valores.Length == 0)
            return 0;
        double produto = 1;
        foreach (var v in valores)
            produto *= v;
        return produto;
    }
}
