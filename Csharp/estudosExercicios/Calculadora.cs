using System;
using System.Text.RegularExpressions;

namespace exercicios
{
    class Calculadora
    {
        public string calcular()
        {
            string numeroDigitado1 = null;
            string numeroDigitado2 = null;
            string retorno = "";

            try
            {
                numeroDigitado1 = lerValor1();
                numeroDigitado2 = lerValor2();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            double doubleNumeroDigitado1 = Convert.ToDouble(numeroDigitado1);
            double doubleNumeroDigitado2 = Convert.ToDouble(numeroDigitado2);

            int operacaoDesejada = escolherOperacao();

            while (operacaoDesejada < 1 || operacaoDesejada > 4)
            {
                operacaoDesejada = verificadorErroOperacaoDesejada();
            }

            bool eSoma = operacaoDesejada == 1;
            bool eSubtracao = operacaoDesejada == 2;
            bool eMultiplicacao = operacaoDesejada == 3;
            bool eDivisao = operacaoDesejada == 4;

            if (eSoma)
            {
                somar(doubleNumeroDigitado1, doubleNumeroDigitado2);

            }

            else if (eSubtracao)
            {
                subtrair(doubleNumeroDigitado1, doubleNumeroDigitado2);

            }

            else if (eMultiplicacao)
            {
                multiplicar(doubleNumeroDigitado1, doubleNumeroDigitado2);

            }

            else if (eDivisao)
            {
                dividir(doubleNumeroDigitado1, doubleNumeroDigitado2);

            }

            return retorno;
        }


        private string lerValor1()
        {
            string retorno = null;
            bool temError = false;
            do
            {
                if (temError)
                {
                    Console.Write("\nInsira o primeiro valor novamente: ");
                }
                else
                {
                    Console.Write("\nInsira o primeiro valor: ");
                }
                retorno = Console.ReadLine();
                temError = Regex.IsMatch(retorno, @"^[0-9]+$") == false;
                if (double.TryParse(retorno, out var a))
                {
                    temError = false;
                }
            }

            while (temError);


            return retorno;
        }

        private string lerValor2()
        {
            string retorno = null;
            bool temError = false;
            do
            {
                if (temError)
                {
                    Console.Write("\nInsira o segundo valor novamente: ");
                }
                else
                {
                    Console.Write("\nInsira o segundo valor: ");
                }
                retorno = Console.ReadLine();
                temError = Regex.IsMatch(retorno, @"^[0-9]+$") == false;
                if (double.TryParse(retorno, out var a))
                {
                    temError = false;
                }
            }

            while (temError);


            return retorno;
        }

        private int escolherOperacao()
        {
            Console.WriteLine("\nQual operação matemática você deseja fazer? Digite:");
            Console.WriteLine("[1] Soma; [2] Subtração; [3]Multiplicação; [4] Divisão");
            Console.Write("\nSua escolha: ");
            int numeroOperacaoDesejada = Convert.ToInt32(Console.ReadLine());
            return numeroOperacaoDesejada;
        }

        private int verificadorErroOperacaoDesejada()
        {
            Console.WriteLine("\nFavor escolha uma operação dentre as opções:");
            Console.WriteLine("[1] Soma; [2] Subtração; [3]Multiplicação; [4] Divisão");
            Console.Write("\nSua escolha: ");
            int numeroOperacaoDesejada = Convert.ToInt32(Console.ReadLine());
            return numeroOperacaoDesejada;
        }

        private void somar(double numero1, double numero2)
        {
            double calculo = numero1 + numero2;
            Console.WriteLine("\nRESULTADO: " + calculo);
        }

        private void subtrair(double numero1, double numero2)
        {
            double calculo = numero1 - numero2;
            Console.WriteLine("\nRESULTADO: " + calculo);
        }
        private void multiplicar(double numero1, double numero2)
        {
            double calculo = numero1 * numero2;
            Console.WriteLine("\nRESULTADO: " + calculo);
        }
        private void dividir(double numero1, double numero2)
        {
            double calculo = numero1 / numero2;
            Console.WriteLine("\nRESULTADO: " + calculo);
        }
    }
}
