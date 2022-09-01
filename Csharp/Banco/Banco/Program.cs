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
            Operacao operacao = new Operacao();
            CadastroCliente cadastroCliente = new CadastroCliente();
            LocalizaInformacoes localizaInformacoes = new LocalizaInformacoes();

            Console.WriteLine("Bem-Vindo ao Banco!\n");

            Console.Write("Digite seu cpf: ");
            string cpfTitular = Console.ReadLine();


            string nomeTitular = string.Empty;
            string emailTitular = string.Empty;

            int numeroConta = 0;
            double saldoConta = 0;
            int numeroTotalClientes = 0;

            string caminhoLerTotalClientes = "D:\\Mauricio\\Estudos-Gerais-main\\Csharp\\Banco\\Banco\\PastaClientes\\totalClientes.txt";
            foreach (string line in File.ReadLines(caminhoLerTotalClientes))
            {
                numeroTotalClientes = Int32.Parse(line);
            }

            Tuple<string, int> tupleLocalizar = localizaInformacoes.localizarCPF(cpfTitular, numeroTotalClientes);
            string teste = tupleLocalizar.Item1;
            int counter = tupleLocalizar.Item2;
            
            int diferenciarMenu = 0;
            string pergunta = "0";
            while (pergunta != "6")
            {
                if (teste == cpfTitular)
                {
                    string caminhoLer = String.Format("D:\\Mauricio\\Estudos-Gerais-main\\Csharp\\Banco\\Banco\\PastaClientes\\{0}.txt", counter);

                    nomeTitular = localizaInformacoes.localizarNome(caminhoLer, diferenciarMenu, nomeTitular);
                    emailTitular = localizaInformacoes.localizarEmail(caminhoLer, emailTitular);

                    Titular titular = new Titular(nomeTitular, cpfTitular, emailTitular);

                    numeroConta = localizaInformacoes.localizarNumeroConta(caminhoLer, numeroConta);
                    saldoConta = localizaInformacoes.localizarSaldoConta(caminhoLer, saldoConta);

                    Conta contaTitular = new Conta();
                    contaTitular.numero = numeroConta;
                    contaTitular.agencia = 217;
                    contaTitular.saldo = saldoConta;

                    Menu menu = new Menu();
                    pergunta = menu.selecionarOpcao();

                    if (pergunta == "1")
                    {
                        operacao.consultarDados(titular.nome, titular.email, contaTitular.numero, contaTitular.agencia);
                    }

                    if (pergunta == "2")
                    {
                        operacao.consultarSaldo(contaTitular.saldo);
                    }

                    if (pergunta == "3")
                    {
                        contaTitular.saldo = operacao.sacarDinheiro(contaTitular.saldo);
                        bancoDados.salvarDadosTitular(titular.cpf, titular.nome, titular.email, contaTitular.numero, contaTitular.agencia, contaTitular.saldo, caminhoLer);
                    }
                    if (pergunta == "4")
                    {
                        contaTitular.saldo = operacao.depositarDinheiro(contaTitular.saldo);
                        bancoDados.salvarDadosTitular(titular.cpf, titular.nome, titular.email, contaTitular.numero, contaTitular.agencia, contaTitular.saldo, caminhoLer);
                    }

                    if (pergunta == "5")
                    {
                        operacao.transferirDinheiro(numeroTotalClientes, contaTitular.saldo, titular.cpf, titular.nome, titular.email, contaTitular.numero, contaTitular.agencia, caminhoLer);
                    }
                }

                if (teste != cpfTitular)
                {
                    Tuple<string, int> tupleCadastrar = cadastroCliente.cadastrarNovoCliente(cpfTitular, numeroTotalClientes, caminhoLerTotalClientes);
                    teste = tupleCadastrar.Item1;
                    counter = tupleCadastrar.Item2;
                    diferenciarMenu = 1;
                }
            }
        }
    }
}
