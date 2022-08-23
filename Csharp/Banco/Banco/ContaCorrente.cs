using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class ContaCorrente : Conta
    {
        public double taxa;

        public double sacar(double saldo, double valor)
        {
            double saque = saldo - valor;
            return saque;
        }

        public double depositar(double saldo, double valor)
        {
            double deposito = saldo + valor;
            return deposito;
        }

        public double transferir(double saldo, double valor)
        {
            double transferencia = saldo - valor;
            return transferencia;
        }

    }
}
