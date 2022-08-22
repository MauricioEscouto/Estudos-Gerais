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

        public double sacar(double valor)
        {
            double saque = saldo - valor;
            saldo = saque;
            return saldo;
        }

        public double depositar(double valor)
        {
            double deposito = saldo + valor;
            saldo = deposito;
            return saldo;
        }

    }
}
