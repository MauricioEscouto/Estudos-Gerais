using System;
using System.IO;

namespace estudos
{
    public class IMCTEXTO
    {
        StreamWriter arquivoTexto = new StreamWriter("C:\\Users\\Suporte\\Desktop\\Mauricio\\Estudos-Gerais\\Csharp\\estudosExercicios\\ArquivosTexto\\IMCsCalculo.txt", true);
        public void escreverIMC(string calculoIMC, string classificacaoIMC)
        {
            arquivoTexto.WriteLine(calculoIMC);
            arquivoTexto.WriteLine(classificacaoIMC);
            arquivoTexto.WriteLine("");
        }
        public void abrirArquivoIMC()
        {
            var data = File.ReadAllText("C:\\Users\\Suporte\\Desktop\\Mauricio\\Estudos-Gerais\\Csharp\\estudosExercicios\\ArquivosTexto\\IMCsCalculo.txt");
            Console.WriteLine(data);
        }

        public void gravarIMC()
        {
            arquivoTexto.Close();
        }

    }


}


