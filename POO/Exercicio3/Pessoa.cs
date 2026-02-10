using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio3
{
    public class Pessoa
    {
        private int idade;

        public string Nome { get; set; }

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

        public void ExibirDados()
        {
            Console.WriteLine($"Nome: {Nome}");
            System.Console.WriteLine($"Idade: {Idade}");
        }
    }
}