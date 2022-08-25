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
            BancoDados bancoDados = new BancoDados();

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
            int numeroTotalClientes = 0;

            string caminhoLerTotalClientes = "C:\\Users\\Suporte\\Desktop\\Mauricio\\Estudos-Gerais\\Csharp\\Banco\\Banco\\PastaClientes\\totalClientes.txt";
            foreach (string line in File.ReadLines(caminhoLerTotalClientes))
            {
                numeroTotalClientes = Int32.Parse(line);
            }

            while (cont < numeroTotalClientes)
            {
                string caminhoLer = String.Format("C:\\Users\\Suporte\\Desktop\\Mauricio\\Estudos-Gerais\\Csharp\\Banco\\Banco\\PastaClientes\\{0}.txt", contArquivo);
                foreach (string line in File.ReadLines(caminhoLer))
                {
                    if (line == cpfTitular)
                    {
                        counter = cont;
                        teste = line;
                        break;
                    }
                    
                }
                cont++;
                contArquivo++;
            }

            int diferenciarMenu = 0;
            string pergunta = "0";
            while (pergunta != "6")
            {
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
                            if(diferenciarMenu == 0)
                            {
                                Console.WriteLine("\nBem-vindo de volta {0}!", nomeTitular);
                            }
                            diferenciarMenu = 1;
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

                    Menu menu = new Menu();
                    pergunta = menu.selecionarOpcao();

                    if (pergunta == "1")
                    {
                        Console.WriteLine("\n-------------------------------------");
                        Console.WriteLine("\nNome: {0}\nE-mail cadastrado: {1}", titular.nome, titular.email);
                        Console.WriteLine("Conta corrente número: {0}\nAgência: {1}", contaTitular.numero, contaTitular.agencia);
                    }

                    if (pergunta == "2")
                    {
                        Console.WriteLine("\n-------------------------------------");
                        Console.WriteLine("\nSeu saldo: {0}", contaTitular.saldo);
                    }

                    if (pergunta == "3")
                    {
                        string perguntaSaque = "1";
                        while (perguntaSaque == "1")
                        {
                            Console.WriteLine("\n-------------------------------------");
                            Console.WriteLine("\nSeu saldo: {0}", contaTitular.saldo);
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
                        bancoDados.salvarDadosTitular(titular.cpf, titular.nome, titular.email, contaTitular.numero, contaTitular.agencia, contaTitular.saldo, caminhoLer);

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
                        bancoDados.salvarDadosTitular(titular.cpf, titular.nome, titular.email, contaTitular.numero, contaTitular.agencia, contaTitular.saldo, caminhoLer);
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
                            string perguntaCpfBeneficiario = Console.ReadLine();

                            int contTransferencia = 1;
                            int contArquivoTransferencia = 1;
                            string nomeBeneficiario = string.Empty;
                            string emailBeneficiario = string.Empty;
                            int numeroContaBeneficiario = 0;
                            int counterTransferencia = 0;

                            while (contTransferencia < numeroTotalClientes)
                            {
                                string caminhoLerTransferencia = String.Format("C:\\Users\\Suporte\\Desktop\\Mauricio\\Estudos-Gerais\\Csharp\\Banco\\Banco\\PastaClientes\\{0}.txt", contArquivoTransferencia);
                                foreach (string line in File.ReadLines(caminhoLerTransferencia))
                                {
                                    if (line == perguntaCpfBeneficiario)
                                    {
                                        counterTransferencia = contTransferencia;
                                        break;
                                    }

                                }
                                contTransferencia++;
                                contArquivoTransferencia++;
                            }

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
                                if (line == "EMAIL")
                                {
                                    string[] readText = File.ReadAllLines(caminhoLerTransferencia1);
                                    emailBeneficiario = readText[readText.Length - 8];
                                    break;
                                }
                            }

                            foreach (string line in File.ReadLines(caminhoLerTransferencia1))
                            {
                                if (line == "NUMERO")
                                {
                                    string[] readText = File.ReadAllLines(caminhoLerTransferencia1);
                                    string procuraNumeroContaBeneficiario = readText[readText.Length - 5];
                                    numeroContaBeneficiario = Int32.Parse(procuraNumeroContaBeneficiario);
                                    break;
                                }
                            }

                            foreach (string line in File.ReadLines(caminhoLerTransferencia1))
                            {
                                if (line == "SALDO")
                                {
                                    string[] readText = File.ReadAllLines(caminhoLerTransferencia1);
                                    string procuraSaldoContaBeneficiario = readText[readText.Length - 1];
                                    saldoContaBeneficiario = Double.Parse(procuraSaldoContaBeneficiario);
                                    break;
                                }
                            }

                            Titular titularBeneficiario = new Titular(nomeBeneficiario, perguntaCpfBeneficiario, emailBeneficiario);
                            Conta contaBeneficiario = new Conta();
                            contaBeneficiario.numero = numeroContaBeneficiario;
                            contaBeneficiario.agencia = 217;
                            contaBeneficiario.saldo = saldoContaBeneficiario;


                            contaBeneficiario.saldo = valorDeTransferencia + contaBeneficiario.saldo;
                            contaTitular.saldo = contacorrente.transferir(contaTitular.saldo, valorDeTransferencia);

                            Console.WriteLine("\n-------------------------------------");
                            Console.WriteLine("Transferência concluída com sucesso!\n");
                            Console.Write("Deseja realizar outra transferência?\n");
                            Console.WriteLine("[1] SIM\n[2] NÃO");
                            Console.Write("Sua escolha: ");
                            perguntaTransferencia = Console.ReadLine();

                            bancoDados.salvarDadosTitular(titular.cpf, titular.nome, titular.email, contaTitular.numero, contaTitular.agencia, contaTitular.saldo, caminhoLer);

                            bancoDados.salvarDadosBeneficiario(titularBeneficiario.cpf, titularBeneficiario.nome, titularBeneficiario.email, contaBeneficiario.numero, contaBeneficiario.agencia, contaBeneficiario.saldo, caminhoLerTransferencia1);
                        }
                    }
                }

                if (teste != cpfTitular)
                {
                    Console.WriteLine("\nNotamos que você não possui cadastro, vamos te encaminhar para a tela de criação de conta.\n");
                    Console.Write("Digite seu nome: ");
                    nomeTitular = Console.ReadLine();
                    Console.Write("Digite seu email: ");
                    emailTitular = Console.ReadLine();

                    Titular titular = new Titular(nomeTitular, cpfTitular, emailTitular);
                    Conta conta = new Conta();
                    int numeroContaGerada = Conta.GerarNumeroConta();
                    conta.numero = numeroContaGerada;
                    conta.agencia = 217;
                    conta.saldo = 0;

                    string caminhoNovoCliente = String.Format("C:\\Users\\Suporte\\Desktop\\Mauricio\\Estudos-Gerais\\Csharp\\Banco\\Banco\\PastaClientes\\{0}.txt", numeroTotalClientes);

                    bancoDados.salvarDadosTitular(titular.cpf, titular.nome, titular.email, conta.numero, conta.agencia, conta.saldo, caminhoNovoCliente);

                    Console.WriteLine("\nConta criada com sucesso! Número da conta: {0}, Agência: {1}", conta.numero, conta.agencia);

                    caminhoLerTotalClientes = "C:\\Users\\Suporte\\Desktop\\Mauricio\\Estudos-Gerais\\Csharp\\Banco\\Banco\\PastaClientes\\totalClientes.txt";
                    StreamWriter arquivoTextoTotalClientes = new StreamWriter(caminhoLerTotalClientes);

                    arquivoTextoTotalClientes.WriteLine(numeroTotalClientes + 1);
                    arquivoTextoTotalClientes.Close();

                    cont = 1;
                    counter = 0;
                    contArquivo = 1;
                    while (cont < numeroTotalClientes + 1)
                    {
                        string caminhoLer = String.Format("C:\\Users\\Suporte\\Desktop\\Mauricio\\Estudos-Gerais\\Csharp\\Banco\\Banco\\PastaClientes\\{0}.txt", contArquivo);
                        foreach (string line in File.ReadLines(caminhoLer))
                        {
                            if (line == cpfTitular)
                            {;
                                counter = cont;
                                teste = line;
                                break;
                            }

                        }
                        cont++;
                        contArquivo++;
                    }
                    diferenciarMenu = 1;
                }
            }
            
        }
    }
}

