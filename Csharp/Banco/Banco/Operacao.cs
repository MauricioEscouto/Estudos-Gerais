using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class Operacao
    {
        ContaCorrente contaCorrente = new ContaCorrente();
        BancoDados bancoDados = new BancoDados();
        public void consultarDados(string Nome, string Email, int NumeroConta, int Agencia)
        {
            Console.WriteLine("\n-------------------------------------");
            Console.WriteLine("\nNome: {0}\nE-mail cadastrado: {1}", Nome, Email);
            Console.WriteLine("Conta corrente número: {0}\nAgência: {1}", NumeroConta, Agencia);
        }

        public void consultarSaldo(double Saldo)
        {
            Console.WriteLine("\n-------------------------------------");
            Console.WriteLine("\nSeu saldo: {0}", Saldo);
        }

        public double sacarDinheiro(double SaldoTitular)
        {
            string perguntaSaque = "1";
            while (perguntaSaque == "1")
            {
                Console.WriteLine("\n-------------------------------------");
                Console.WriteLine("\nSeu saldo: {0}", SaldoTitular);
                Console.Write("Informe o valor do saque: ");
                double valor = Double.Parse(Console.ReadLine());
                if (valor > SaldoTitular)
                {
                    Console.Write("\nO valor informado é maior do que seu saldo de R${0}\n", SaldoTitular);
                    Console.Write("Informe um valor de saque menor ou igual ao seu saldo: ");
                    valor = Double.Parse(Console.ReadLine());
                }
                SaldoTitular = contaCorrente.sacar(SaldoTitular, valor);
                Console.WriteLine("\n-------------------------------------");
                Console.WriteLine("\nSaque realizado com sucesso!");
                Console.WriteLine("\n-------------------------------------\n");

                Console.WriteLine("Deseja efetuar mais um saque?\n");
                Console.WriteLine("[1] SIM\n[2] NÃO");
                Console.Write("Sua escolha: ");
                perguntaSaque = Console.ReadLine();
            }
            double saldoPosSaque = SaldoTitular;
            return saldoPosSaque;
        }

        public double depositarDinheiro(double SaldoTitular)
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
                SaldoTitular = contaCorrente.depositar(SaldoTitular, valor);
                Console.WriteLine("\n-------------------------------------");
                Console.WriteLine("\nDepósito realizado com sucesso!");
                Console.WriteLine("\n-------------------------------------\n");

                Console.WriteLine("Deseja efetuar mais um depósito?\n");
                Console.WriteLine("[1] SIM\n[2] NÃO");
                Console.Write("Sua escolha: ");
                perguntaDeposito = Console.ReadLine();
            }
            double saldoPosDeposito = SaldoTitular;
            return saldoPosDeposito;
        }

        public void transferirDinheiro(int numeroTotalClientes, double saldoTitutlar, string CpfTitutlar, string NomeTitular, string EmailTitutlar, int NumeroContaTitular, int AgenciaContaTitutlar, string CaminhoArquivoTitular)
        {
            double saldoContaBeneficiario = 0;

            string perguntaTransferencia = "1";
            while (perguntaTransferencia == "1")
            {
                Console.WriteLine("\n-------------------------------------");
                Console.Write("Informe o valor de transferência: ");
                double valorDeTransferencia = Double.Parse(Console.ReadLine());
                while (valorDeTransferencia < 1 || valorDeTransferencia > saldoTitutlar)
                {
                    if (valorDeTransferencia < 1)
                    {
                        Console.Write("\nO valor informado deve ser maior que R$1,00\n");
                        Console.Write("Informe um novo valor de transferência: ");
                        valorDeTransferencia = Double.Parse(Console.ReadLine());
                    }
                    if (valorDeTransferencia > saldoTitutlar)
                    {
                        Console.Write("\nO valor informado é maior do que seu saldo de R${0}\n", saldoTitutlar);
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
                saldoTitutlar = contaCorrente.transferir(saldoTitutlar, valorDeTransferencia);

                Console.WriteLine("\n-------------------------------------");
                Console.WriteLine("Transferência concluída com sucesso!\n");
                Console.Write("Deseja realizar outra transferência?\n");
                Console.WriteLine("[1] SIM\n[2] NÃO");
                Console.Write("Sua escolha: ");
                perguntaTransferencia = Console.ReadLine();

                bancoDados.salvarDadosTitular(CpfTitutlar, NomeTitular, EmailTitutlar, NumeroContaTitular, AgenciaContaTitutlar, saldoTitutlar, CaminhoArquivoTitular);
                bancoDados.salvarDadosBeneficiario(titularBeneficiario.cpf, titularBeneficiario.nome, titularBeneficiario.email, contaBeneficiario.numero, contaBeneficiario.agencia, contaBeneficiario.saldo, caminhoLerTransferencia1);
            }

        }
    }    
}
