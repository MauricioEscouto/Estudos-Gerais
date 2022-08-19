using System;


namespace estudos
{
    class IMC
    {
        public double calcularIMC(double peso, double altura)
        {
            double calculo = peso / (Math.Pow(altura, 2));
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("\nValor do seu IMC: " + calculo);
            return calculo;
        }

    }
}
