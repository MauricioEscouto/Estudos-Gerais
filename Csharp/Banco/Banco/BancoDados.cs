using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Banco
{
    public class BancoDados
    {
        public void salvarDadosTitular(string Cpf, string Nome, string Email, int Numero, int Agencia, double Saldo, string caminhoArquivo)
        {
            StreamWriter arquivoTextoTitular = new StreamWriter(caminhoArquivo);
            arquivoTextoTitular.WriteLine("CPF");
            arquivoTextoTitular.WriteLine(Cpf);
            arquivoTextoTitular.WriteLine("NOME");
            arquivoTextoTitular.WriteLine(Nome);
            arquivoTextoTitular.WriteLine("EMAIL");
            arquivoTextoTitular.WriteLine(Email);
            arquivoTextoTitular.WriteLine("CONTA");
            arquivoTextoTitular.WriteLine("NUMERO");
            arquivoTextoTitular.WriteLine(Numero);
            arquivoTextoTitular.WriteLine("AGENCIA");
            arquivoTextoTitular.WriteLine(Agencia);
            arquivoTextoTitular.WriteLine("SALDO");
            arquivoTextoTitular.WriteLine(Saldo);
            arquivoTextoTitular.Close();
        }
        public void salvarDadosBeneficiario(string Cpf, string Nome, string Email, int Numero, int Agencia, double Saldo, string caminhoArquivo)
        {
            StreamWriter arquivoTextoBeneficiario = new StreamWriter(caminhoArquivo);
            arquivoTextoBeneficiario.WriteLine("CPF");
            arquivoTextoBeneficiario.WriteLine(Cpf);
            arquivoTextoBeneficiario.WriteLine("NOME");
            arquivoTextoBeneficiario.WriteLine(Nome);
            arquivoTextoBeneficiario.WriteLine("EMAIL");
            arquivoTextoBeneficiario.WriteLine(Email);
            arquivoTextoBeneficiario.WriteLine("CONTA");
            arquivoTextoBeneficiario.WriteLine("NUMERO");
            arquivoTextoBeneficiario.WriteLine(Numero);
            arquivoTextoBeneficiario.WriteLine("AGENCIA");
            arquivoTextoBeneficiario.WriteLine(Agencia);
            arquivoTextoBeneficiario.WriteLine("SALDO");
            arquivoTextoBeneficiario.WriteLine(Saldo);
            arquivoTextoBeneficiario.Close();
        }

        public void salvarDadosNovoCliente(string Cpf, string Nome, string Email, int Numero, int Agencia, double Saldo, string caminhoArquivo)
        {
            StreamWriter arquivoTextoNovoCliente = new StreamWriter(caminhoArquivo);
            arquivoTextoNovoCliente.WriteLine("CPF");
            arquivoTextoNovoCliente.WriteLine(Cpf);
            arquivoTextoNovoCliente.WriteLine("NOME");
            arquivoTextoNovoCliente.WriteLine(Nome);
            arquivoTextoNovoCliente.WriteLine("EMAIL");
            arquivoTextoNovoCliente.WriteLine(Email);
            arquivoTextoNovoCliente.WriteLine("CONTA");
            arquivoTextoNovoCliente.WriteLine("NUMERO");
            arquivoTextoNovoCliente.WriteLine(Numero);
            arquivoTextoNovoCliente.WriteLine("AGENCIA");
            arquivoTextoNovoCliente.WriteLine(Agencia);
            arquivoTextoNovoCliente.WriteLine("SALDO");
            arquivoTextoNovoCliente.WriteLine(Saldo);
            arquivoTextoNovoCliente.Close();
        }




    }
}
