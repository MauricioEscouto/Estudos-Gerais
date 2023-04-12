using System;
using System.Collections.Generic;
using System.Linq;

namespace aula15
{
    class aula1
    {
        static void Main(string[] args)
        {
            aula1 aula1 = new aula1();
            //aula1.imprimirParImpar();
            //aula1.imprimi1a100();
        }

        void imprimirParImpar ()
        {
            List<int> listaNumeros = new List<int>();
            listaNumeros.AddRange(Enumerable.Range(1, 100));
            listaNumeros.ForEach(n => validarParImpar(n));

            void validarParImpar(int n)
            {
                if (n % 2 == 0)
                {
                    Console.WriteLine($"Par {n}");
                }
                else
                {
                    Console.WriteLine($"Ímpar {n}");
                }
            }
        }

        void imprimi1a100()
        {
            List<int> listaNumeros = new List<int>();
            listaNumeros.AddRange(Enumerable.Range(1, 100));
            listaNumeros.ForEach(n => Console.WriteLine($"{n}"));
        }
    }
}



