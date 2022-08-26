using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class CadastroCliente
    {
        BancoDados bancoDados = new BancoDados();
        public Tuple<string, int> cadastrarNovoCliente(string CpfNovoCliente, int NumeroTotalClientes, string CaminhoLerTotalClientes)
        {
            Console.WriteLine("\nNotamos que você não possui cadastro, vamos te encaminhar para a tela de criação de conta.\n");
            Console.Write("Digite seu nome: ");
            string nomeTitular = Console.ReadLine();
            Console.Write("Digite seu email: ");
            string emailTitular = Console.ReadLine();

            Titular titular = new Titular(nomeTitular, CpfNovoCliente, emailTitular);
            Conta conta = new Conta();
            int numeroContaGerada = Conta.GerarNumeroConta();
            conta.numero = numeroContaGerada;
            conta.agencia = 217;
            conta.saldo = 0;

            string caminhoNovoCliente = String.Format("C:\\Users\\Suporte\\Desktop\\Mauricio\\Estudos-Gerais\\Csharp\\Banco\\Banco\\PastaClientes\\{0}.txt", NumeroTotalClientes);

            bancoDados.salvarDadosTitular(titular.cpf, titular.nome, titular.email, conta.numero, conta.agencia, conta.saldo, caminhoNovoCliente);

            Console.WriteLine("\nConta criada com sucesso! Número da conta: {0}, Agência: {1}", conta.numero, conta.agencia);

            CaminhoLerTotalClientes = "C:\\Users\\Suporte\\Desktop\\Mauricio\\Estudos-Gerais\\Csharp\\Banco\\Banco\\PastaClientes\\totalClientes.txt";
            StreamWriter arquivoTextoTotalClientes = new StreamWriter(CaminhoLerTotalClientes);

            arquivoTextoTotalClientes.WriteLine(NumeroTotalClientes + 1);
            arquivoTextoTotalClientes.Close();

            string teste = string.Empty;
            int cont = 1;
            int counter = 0;
            int contArquivo = 1;
            while (cont < NumeroTotalClientes + 1)
            {
                string caminhoLer = String.Format("C:\\Users\\Suporte\\Desktop\\Mauricio\\Estudos-Gerais\\Csharp\\Banco\\Banco\\PastaClientes\\{0}.txt", contArquivo);
                foreach (string line in File.ReadLines(caminhoLer))
                {
                    if (line == CpfNovoCliente)
                    {
                        
                        counter = cont;
                        teste = line;
                        break;
                    }

                }
                cont++;
                contArquivo++;
            }
            return Tuple.Create(teste, counter);
        }
    }
}
