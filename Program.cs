using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceCorreios
{
    using CorreiosService;
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe O CEP que Deseja Pesquisar:");
            var cep = Console.ReadLine();

            if (!string.IsNullOrEmpty(cep))
            {
                ConsultaCep(cep);
            }
        }

        private static void ConsultaCep(string cep)
        {
            using (var ws = new AtendeClienteService())
            {
                
                try
                {
                    var resposta = ws.consultaCEP(cep);
                    Console.Clear();
                   
                    Console.WriteLine(String.Format("Endereço : {0}", resposta.end));
                    Console.WriteLine(String.Format("Bairro : {0}", resposta.bairro));
                    Console.WriteLine(String.Format("Cidade : {0}", resposta.cidade));
                    Console.WriteLine(String.Format("CEP : {0}", resposta.cep));
                    Console.WriteLine("Pressione Qualquer Tecla para Fechar...");
                    Console.ReadKey();
                  
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    Console.WriteLine("Pressione Qualquer Tecla para Fechar...");
                    Console.ReadKey();
                }
                
            }
        }
    }
}
