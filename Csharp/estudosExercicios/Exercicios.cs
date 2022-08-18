using System;

namespace exercicios
{
    class Exercicios
    {
        public string parOuImpar()
        {
            int NumeroDigitado;
            Console.Write("Insira um número: ");
            NumeroDigitado = Convert.ToInt32(Console.ReadLine());
            string resultado = "";

            bool ePar = NumeroDigitado % 2 == 0;
            if (ePar)
            {
                Console.WriteLine("Número digitado é par");
            }
            else
            {
                Console.WriteLine("Número digitado é ímpar");
            }

            return resultado;
        }



        public string nomeNaTela()
        {
            Console.Write("Insira seu nome: ");
            string nome = Console.ReadLine();

            return nome;
        }
    }

}



