using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class Conta
    {

        public int numero;
        public int agencia;
        public double saldo;

        public static int GerarNumeroConta()
        {
            Random a = new Random(DateTime.Now.Ticks.GetHashCode());
            Thread.Sleep(1);
            return a.Next(100000, 999999);
        }
    }
}
