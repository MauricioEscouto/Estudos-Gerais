using System;

namespace estudos

{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercicios exercicio1 = new Exercicios();
            //Console.WriteLine(exercicio1.parOuImpar());

            //Exercicios exercicio2 = new Exercicios();
            //Console.WriteLine("\nNome digitado foi: " + exercicio2.nomeNaTela());

            //Calculadora exercicio3 = new Calculadora();
            //Console.WriteLine(exercicio3.calcular());

            //CalculadoraReajuste calculadoraReajuste =  new CalculadoraReajuste();
            //ReajusteDiretor reajusteDiretor = new ReajusteDiretor();
            //float salario = calculadoraReajuste.calcular(reajusteDiretor, 1800f);
            //Console.WriteLine("salário com reajuste: " + salario);

            IMC imc = new IMC();
            IMCTEXTO imctexto = new IMCTEXTO();

            Console.Write("Informe seu peso: ");
            double peso = Double.Parse(Console.ReadLine());

            Console.Write("Informe sua altura: ");
            double altura = Double.Parse(Console.ReadLine());

            double valorIMC = imc.calcularIMC(peso, altura);

            if (valorIMC > 18.5 && valorIMC < 25)
            {
                Console.WriteLine("A classificação do seu IMC é: Peso normal");
                imctexto.escreverIMC("O cálculo do seu IMC deu: " + valorIMC, "A classificação do seu IMC é: Peso normal");
            }
            else if (valorIMC > 25 && valorIMC < 30)
            {
                Console.WriteLine("A classificação do seu IMC é: Sobre peso");
                imctexto.escreverIMC("O cálculo do seu IMC deu: " + valorIMC, "A classificação do seu IMC é: Sobre peso");
            }



            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("\nEscolha uma operação a ser feita:\n \n[G]-Gravar\n[L]-Ler\n[S]Sair");
            Console.Write("\nInforme a operação desejada: ");
            string operacaoDesejada = Console.ReadLine();
            Console.WriteLine("\n---------------------------------\n");

            while (operacaoDesejada != "G" && operacaoDesejada != "g" && operacaoDesejada != "L" && operacaoDesejada != "l" && operacaoDesejada != "S" && operacaoDesejada != "s")
            {
                Console.WriteLine("Desculpe, não consegui entender. Vamos tentar novamente");
                Console.WriteLine("\nEscolha uma operação a ser feita:\n \n[G]-Gravar\n[L]-Ler\n[S]Sair");
                Console.Write("\nInforme a operação desejada: ");
                operacaoDesejada = Console.ReadLine();
                Console.WriteLine("\n---------------------------------\n");
            }

            if (operacaoDesejada == "G" || operacaoDesejada == "g")
            {
                imctexto.gravarIMC();
                Console.WriteLine("Cálculo IMC gravado com sucesso! Deseja ler o arquivo? Digite\n \n[S] para SIM \n[N] para Não");
                Console.Write("\nSua escolha: ");
                operacaoDesejada = Console.ReadLine();
                Console.WriteLine("");
                if (operacaoDesejada == "S" || operacaoDesejada == "s")
                {
                    operacaoDesejada = "L";
                }
            }

            if (operacaoDesejada == "L" || operacaoDesejada == "l")
            {
                imctexto.gravarIMC();
                imctexto.abrirArquivoIMC();
                Console.WriteLine("-------------------------------\n");
            }

            if (operacaoDesejada == "S" || operacaoDesejada == "s")
            {
                Console.WriteLine("\nTenha um ótimo dia! :)");
            }
        }
    }
}
