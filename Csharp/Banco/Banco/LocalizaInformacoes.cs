using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class LocalizaInformacoes
    {
        public Tuple<string, int> localizarCPF(string CpfNovoCliente, int NumeroTotalClientes)
        {
            int cont = 1;
            int counter = 0;
            int contArquivo = 1;
            string teste = "";

            while (cont < NumeroTotalClientes)
            {
                string caminhoLer = String.Format("D:\\Mauricio\\Estudos-Gerais-main\\Csharp\\Banco\\Banco\\PastaClientes\\{0}.txt", contArquivo);
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

        public string localizarNome(string CaminhoArquivo, int DiferenciarMenu, string NomeTitular)
        {
            foreach (string line in File.ReadLines(CaminhoArquivo))
            {
                if (line == "NOME")
                {
                    string[] readText = File.ReadAllLines(CaminhoArquivo);
                    NomeTitular = readText[readText.Length - 10];
                    NomeTitular = char.ToUpper(NomeTitular[0]) + NomeTitular.Substring(1);
                    if (DiferenciarMenu == 0)
                    {
                        Console.WriteLine("\nBem-vindo de volta {0}!", NomeTitular);
                    }
                    DiferenciarMenu = 1;
                    break;
                }
            }
            return NomeTitular;
        }

        public string localizarEmail(string CaminhoArquivo, string EmailTitular)
        {
            foreach (string line in File.ReadLines(CaminhoArquivo))
            {
                if (line == "EMAIL")
                {
                    string[] readText = File.ReadAllLines(CaminhoArquivo);
                    EmailTitular = readText[readText.Length - 8];
                    break;
                }
            }
            return EmailTitular;
        }

        public int localizarNumeroConta(string CaminhoArquivo, int NumeroConta)
        {
            foreach (string line in File.ReadLines(CaminhoArquivo))
            {
                if (line == "NUMERO")
                {
                    string[] readText = File.ReadAllLines(CaminhoArquivo);
                    string procuraNumeroConta = readText[readText.Length - 5];
                    NumeroConta = Int32.Parse(procuraNumeroConta);
                    break;
                }
            }
            return NumeroConta;
        }

        public double localizarSaldoConta(string CaminhoArquivo, double SaldoConta)
        {
            foreach (string line in File.ReadLines(CaminhoArquivo))
            {
                if (line == "SALDO")
                {
                    string[] readText = File.ReadAllLines(CaminhoArquivo);
                    string procuraSaldoConta = readText[readText.Length - 1];
                    SaldoConta = Double.Parse(procuraSaldoConta);
                    break;
                }
            }
            return SaldoConta;
        }
    }
}
