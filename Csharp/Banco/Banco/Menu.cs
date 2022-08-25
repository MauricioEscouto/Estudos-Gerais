using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class Menu
    {
        public string selecionarOpcao()
        {
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

            return pergunta;
        }
    }
}
