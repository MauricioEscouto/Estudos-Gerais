using System;
using System.Collections.Generic;
using System.IO;

namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contacorrente = new ContaCorrente();

            Console.WriteLine("Bem-Vindo ao Banco!\n");

            Console.Write("Digite seu cpf: ");
            string cpfTitular = Console.ReadLine();


            string nomeTitular = string.Empty;
            string emailTitular = string.Empty;

            int numeroConta = 0;
            double saldoConta = 0;

            int cont = 1;
            int counter = 0;
            int contArquivo = 1;
            string teste = "";

            while (cont < 3)
            {
                string caminhoLer = String.Format("C:\\Users\\Suporte\\Desktop\\Mauricio\\Estudos-Gerais\\Csharp\\Banco\\Banco\\PastaClientes\\{0}.txt", contArquivo);
                foreach (string line in File.ReadLines(caminhoLer))
                {
                    if (line == cpfTitular)
                    {
                        Console.WriteLine(cont);
                        counter = cont;
                        teste = line;
                        break;
                    }
                    
                }
                cont++;
                contArquivo++;
            }

            if (teste == cpfTitular)
            {
                string caminhoLer = String.Format("C:\\Users\\Suporte\\Desktop\\Mauricio\\Estudos-Gerais\\Csharp\\Banco\\Banco\\PastaClientes\\{0}.txt", counter);
                foreach (string line in File.ReadLines(caminhoLer))
                {
                    if (line == "NOME")
                    {
                        string[] readText = File.ReadAllLines(caminhoLer);
                        nomeTitular = readText[readText.Length - 10];
                        nomeTitular = char.ToUpper(nomeTitular[0]) + nomeTitular.Substring(1);
                        Console.WriteLine("\nBem-vindo de volta {0}!", nomeTitular);
                        break;
                    }
                }

                foreach (string line in File.ReadLines(caminhoLer))
                {
                    if (line == "EMAIL")
                    {
                        string[] readText = File.ReadAllLines(caminhoLer);
                        emailTitular = readText[readText.Length - 8];
                        break;
                    }
                }
                Titular titular = new Titular(nomeTitular, cpfTitular, emailTitular);


                foreach (string line in File.ReadLines(caminhoLer))
                {
                    if (line == "NUMERO")
                    {
                        string[] readText = File.ReadAllLines(caminhoLer);
                        string procuraNumeroConta = readText[readText.Length - 5];
                        numeroConta = Int32.Parse(procuraNumeroConta);
                        break;
                    }
                }
                foreach (string line in File.ReadLines(caminhoLer))
                {
                    if (line == "SALDO")
                    {
                        string[] readText = File.ReadAllLines(caminhoLer);
                        string procuraSaldoConta = readText[readText.Length - 1];
                        saldoConta = Double.Parse(procuraSaldoConta);
                        break;
                    }
                }

                Conta contaTitular = new Conta();
                contaTitular.numero = numeroConta;
                contaTitular.agencia = 217;
                contaTitular.saldo = saldoConta;

                Console.WriteLine("\n-------------------------------------");
                Console.WriteLine("[1]Consultar dados");
                Console.WriteLine("[2]Consultar saldo");
                Console.WriteLine("[3]Sacar dinheiro");
                Console.WriteLine("[4]Depositar dinheiro");
                Console.WriteLine("[5]Transferir dinheiro");
                Console.WriteLine("[6]Fechar o App");
                Console.WriteLine("-------------------------------------\n");

                Console.WriteLine("Informe com número a opção desejada");
                Console.Write("Sua escolha: ");
                string pergunta = Console.ReadLine();


                if (pergunta == "1")
                {
                    Console.WriteLine("\n-------------------------------------");
                    Console.WriteLine("Nome: {0}\nE-mail cadastrado: {1}", titular.nome, titular.email);
                    Console.WriteLine("Conta corrente número: {0}\nAgência: {1}", contaTitular.numero, contaTitular.agencia);
                    Console.WriteLine("-------------------------------------\n");
                }

                if (pergunta == "2")
                {
                    Console.WriteLine("\n-------------------------------------");
                    Console.WriteLine("Seu saldo: {0}", contaTitular.saldo);
                    Console.WriteLine("-------------------------------------\n");
                }

                if (pergunta == "3")
                {
                    string perguntaSaque = "1";
                    while (perguntaSaque == "1") {
                        Console.WriteLine("\n-------------------------------------");
                        Console.Write("Informe o valor do saque: ");
                        double valor = Double.Parse(Console.ReadLine());
                        if (valor > contaTitular.saldo)
                        {
                            Console.Write("\nO valor informado é maior do que seu saldo de R${0}\n", contaTitular.saldo);
                            Console.Write("Informe um valor de saque menor ou igual ao seu saldo: ");
                            valor = Double.Parse(Console.ReadLine());
                        }
                        contaTitular.saldo = contacorrente.sacar(contaTitular.saldo, valor);
                        Console.WriteLine("\n-------------------------------------");
                        Console.WriteLine("\nSaque realizado com sucesso!");
                        Console.WriteLine("\n-------------------------------------\n");

                        Console.WriteLine("Deseja efetuar mais um saque?\n");
                        Console.WriteLine("[1] SIM\n[2] NÃO");
                        Console.Write("Sua escolha: ");
                        perguntaSaque = Console.ReadLine();
                    }
                    StreamWriter arquivoTexto = new StreamWriter(caminhoLer);
                    arquivoTexto.WriteLine("CPF");
                    arquivoTexto.WriteLine(titular.cpf);
                    arquivoTexto.WriteLine("NOME");
                    arquivoTexto.WriteLine(titular.nome);
                    arquivoTexto.WriteLine("EMAIL");
                    arquivoTexto.WriteLine(titular.email);
                    arquivoTexto.WriteLine("CONTA");
                    arquivoTexto.WriteLine("NUMERO");
                    arquivoTexto.WriteLine(contaTitular.numero);
                    arquivoTexto.WriteLine("AGENCIA");
                    arquivoTexto.WriteLine(contaTitular.agencia);
                    arquivoTexto.WriteLine("SALDO");
                    arquivoTexto.WriteLine(contaTitular.saldo);
                    arquivoTexto.Close();
                }
                if (pergunta == "4")
                {
                    string perguntaDeposito = "1";
                    while (perguntaDeposito == "1")
                    {
                        Console.WriteLine("\n-------------------------------------");
                        Console.Write("Informe o valor do depósito: ");
                        double valor = Double.Parse(Console.ReadLine());
                        if (valor < 1)
                        {
                            Console.Write("\nO valor de depósito deve ser maior que R$1,00\n");
                            Console.Write("Informe um novo valor de depósito: ");
                            valor = Double.Parse(Console.ReadLine());
                        }
                        contaTitular.saldo = contacorrente.depositar(contaTitular.saldo, valor);
                        Console.WriteLine("\n-------------------------------------");
                        Console.WriteLine("\nDepósito realizado com sucesso!");
                        Console.WriteLine("\n-------------------------------------\n");

                        Console.WriteLine("Deseja efetuar mais um depósito?\n");
                        Console.WriteLine("[1] SIM\n[2] NÃO");
                        Console.Write("Sua escolha: ");
                        perguntaDeposito = Console.ReadLine();
                    }
                    StreamWriter arquivoTexto = new StreamWriter(caminhoLer);
                    arquivoTexto.WriteLine("CPF");
                    arquivoTexto.WriteLine(titular.cpf);
                    arquivoTexto.WriteLine("NOME");
                    arquivoTexto.WriteLine(titular.nome);
                    arquivoTexto.WriteLine("EMAIL");
                    arquivoTexto.WriteLine(titular.email);
                    arquivoTexto.WriteLine("CONTA");
                    arquivoTexto.WriteLine("NUMERO");
                    arquivoTexto.WriteLine(contaTitular.numero);
                    arquivoTexto.WriteLine("AGENCIA");
                    arquivoTexto.WriteLine(contaTitular.agencia);
                    arquivoTexto.WriteLine("SALDO");
                    arquivoTexto.WriteLine(contaTitular.saldo);
                    arquivoTexto.Close();
                }
                
                if (pergunta == "5")
                {
                    double saldoContaBeneficiario = 0;

                    string perguntaTransferencia = "1";
                    while (perguntaTransferencia == "1")
                    {
                        Console.WriteLine("\n-------------------------------------");
                        Console.Write("Informe o valor de transferência: ");
                        double valorDeTransferencia = Double.Parse(Console.ReadLine());
                        while (valorDeTransferencia < 1 || valorDeTransferencia > contaTitular.saldo)
                        {
                            if (valorDeTransferencia < 1)
                            {
                                Console.Write("\nO valor informado deve ser maior que R$1,00\n");
                                Console.Write("Informe um novo valor de transferência: ");
                                valorDeTransferencia = Double.Parse(Console.ReadLine());
                            }
                            if (valorDeTransferencia > contaTitular.saldo)
                            {
                                Console.Write("\nO valor informado é maior do que seu saldo de R${0}\n", contaTitular.saldo);
                                Console.Write("Favor informe um valor de transferência maior ou igual ao seu saldo: ");
                                valorDeTransferencia = Double.Parse(Console.ReadLine());
                            }
                        }
                        Console.WriteLine("\n---------------\n");
                        Console.Write("Informe o CPF do beneficiário: ");
                        string perguntaBeneficiario = Console.ReadLine();

                        int contTransferencia = 1;
                        int contArquivoTransferencia = 1;
                        string nomeBeneficiario = string.Empty;
                        int counterTransferencia = 0;

                        while (contTransferencia < 4)
                        {
                            string caminhoLerTransferencia = String.Format("C:\\Users\\Suporte\\Desktop\\Mauricio\\Estudos-Gerais\\Csharp\\Banco\\Banco\\PastaClientes\\{0}.txt", contArquivoTransferencia);
                            foreach (string line in File.ReadLines(caminhoLerTransferencia))
                            {
                                if (line == perguntaBeneficiario)
                                {
                                    //Console.WriteLine(cont);
                                    counterTransferencia = contTransferencia;
                                    //teste = line;
                                    break;
                                }

                            }
                            contTransferencia++;
                            contArquivoTransferencia++;
                        }
                        Console.WriteLine(counterTransferencia);

                        string caminhoLerTransferencia1 = String.Format("C:\\Users\\Suporte\\Desktop\\Mauricio\\Estudos-Gerais\\Csharp\\Banco\\Banco\\PastaClientes\\{0}.txt", counterTransferencia);
                        foreach (string line in File.ReadLines(caminhoLerTransferencia1))
                        {

                            if (line == "NOME")
                            {
                                string[] readText = File.ReadAllLines(caminhoLerTransferencia1);
                                nomeBeneficiario = readText[readText.Length - 10];
                                nomeBeneficiario = char.ToUpper(nomeBeneficiario[0]) + nomeBeneficiario.Substring(1);
                                break;
                            }
                        }

                        Console.WriteLine("\nO nome do beneficiário que você deseja realizar a transferência é {0}?", nomeBeneficiario);
                        Console.WriteLine("[1] SIM\n[2] NÃO");
                        Console.Write("Sua escolha: ");
                        string perguntaNomeAchado = Console.ReadLine();

                        foreach (string line in File.ReadLines(caminhoLerTransferencia1))
                        {
                            if (line == "SALDO")
                            {
                                string[] readText = File.ReadAllLines(caminhoLerTransferencia1);
                                string procuraSaldoContaBeneficiario = readText[readText.Length - 1];
                                saldoContaBeneficiario = Double.Parse(procuraSaldoContaBeneficiario);
                                Console.WriteLine(saldoContaBeneficiario);
                                break;
                            }
                        }

                        double saldoContaBeneficiarioPosTransferencia = valorDeTransferencia + saldoContaBeneficiario;
                        contaTitular.saldo =  contacorrente.transferir(contaTitular.saldo, valorDeTransferencia);

                        Console.WriteLine("\n-------------------------------------");
                        Console.WriteLine("Transferência concluída com sucesso!\n");
                        Console.Write("Deseja realizar outra transferência?\n");
                        Console.WriteLine("[1] SIM\n[2] NÃO");
                        Console.Write("Sua escolha: ");
                        perguntaTransferencia = Console.ReadLine();

                        Console.WriteLine("Beneficiario: {0}", saldoContaBeneficiarioPosTransferencia);
                        Console.WriteLine("Titular: {0}", contaTitular.saldo);


                    }

                        //conta.saldo = contacorrente.depositar(conta.saldo, valor);








                    }
                }
            }









            //if (teste != cpfTitular)
            //{
            //    Console.WriteLine("\nNotamos que você não possui cadastro, vamos te encaminhar para a tela de criação de conta.\n");
            //    Console.Write("Digite seu nome: ");
            //    nomeTitular = Console.ReadLine();
            //    Console.Write("Digite seu email: ");
            //    emailTitular = Console.ReadLine();

            //    Titular titular = new Titular(nomeTitular, cpfTitular, emailTitular);
            //    Conta conta = new Conta();
            //    int numeroContaGerada = Conta.GerarNumeroConta();
            //    conta.numero = numeroContaGerada;
            //    conta.agencia = 217;

            //    string caminho = "C:\\Users\\Suporte\\Desktop\\Mauricio\\Estudos-Gerais\\Csharp\\Banco\\Banco\\PastaClientes\\3.txt";
            //    StreamWriter arquivoTexto = new StreamWriter(caminho);

            //    arquivoTexto.WriteLine("CPF");
            //    arquivoTexto.WriteLine(titular.cpf);
            //    arquivoTexto.WriteLine("NOME");
            //    arquivoTexto.WriteLine(titular.nome);
            //    arquivoTexto.WriteLine("EMAIL");
            //    arquivoTexto.WriteLine(titular.email);
            //    arquivoTexto.WriteLine("CONTA");
            //    arquivoTexto.WriteLine("NUMERO");
            //    arquivoTexto.WriteLine(conta.numero);
            //    arquivoTexto.WriteLine("AGENCIA");
            //    arquivoTexto.WriteLine(conta.agencia);
            //    arquivoTexto.WriteLine("SALDO");
            //    arquivoTexto.WriteLine(0);
            //    arquivoTexto.Close();

            //    Console.WriteLine("\nConta criada com sucesso! Número da conta: {0}, Agência: {1}",conta.numero,conta.agencia);
            //}























            //string nome = "1";
            //string teste = String.Format("C:\\Users\\Suporte\\Desktop\\Mauricio\\Estudos-Gerais\\Csharp\\estudosExercicios\\ArquivosTexto\\{0}.txt", nome);












            
            //conta.saldo = contacorrente.depositar(100);
            //Console.WriteLine(conta.saldo);

        }
    }

