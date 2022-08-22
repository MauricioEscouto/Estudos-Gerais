using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class Titular
    {
        public Titular(string Nome, string Cpf, string Email)
        {
            nome = Nome;
            cpf = Cpf;
            email = Email;
        }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }



    }
}
