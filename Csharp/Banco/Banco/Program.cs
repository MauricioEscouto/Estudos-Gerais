using System;
using System.Collections.Generic;
using System.IO;

namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Bem-Vindo ao Banco!\n");

            Console.Write("Digite seu cpf: ");
            string cpfTitular = Console.ReadLine();

            int cont = 1;
            int counter = 0;
            string cont2 = "1";

            while (cont < 3)
            {
                
                string caminhoLer = String.Format("C:\\Users\\Suporte\\Desktop\\Mauricio\\Estudos-Gerais\\Csharp\\Banco\\Banco\\PastaClientes\\{0}.txt", cont2);
                foreach (string line in File.ReadLines(caminhoLer))
                {
                    if (line == cpfTitular)
                    {
                        string teste = "sim";
                        Console.WriteLine(teste);
                    }
                    counter++;
                }
                cont++;
                cont2 = "2";
            }

            Console.Write("Digite seu nome: ");
            string nomeTitular = Console.ReadLine();

            Console.Write("Digite seu email: ");
            string emailTitular = Console.ReadLine();

            List<Titular> listacliente = new List<Titular>();

            Titular titular = new Titular(nomeTitular, cpfTitular, emailTitular);

            listacliente.Add(titular);


            Conta conta = new Conta();
            conta.numero = 317698;
            conta.agencia = 217;




            //string nome = "1";
            //string teste = String.Format("C:\\Users\\Suporte\\Desktop\\Mauricio\\Estudos-Gerais\\Csharp\\estudosExercicios\\ArquivosTexto\\{0}.txt", nome);
            string caminho = "C:\\Users\\Suporte\\Desktop\\Mauricio\\Estudos-Gerais\\Csharp\\Banco\\Banco\\PastaClientes\\1.txt";
            StreamWriter arquivoTexto = new StreamWriter(caminho,true);
            //arquivoTexto.Close();
            //System.IO.File.Move(caminho, teste);
            arquivoTexto.WriteLine(listacliente[0].cpf);
            arquivoTexto.WriteLine(listacliente[0].nome);
            arquivoTexto.WriteLine(listacliente[0].email);
            arquivoTexto.Close();

            

            
            






            //ContaCorrente contacorrente = new ContaCorrente();
            //conta.saldo = contacorrente.depositar(100);
            //Console.WriteLine(conta.saldo);

        }
    }
}
