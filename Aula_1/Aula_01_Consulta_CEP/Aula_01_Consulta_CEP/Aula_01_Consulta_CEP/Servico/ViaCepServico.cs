using Aula_01_Consulta_CEP.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json;

namespace Aula_01_Consulta_CEP.Servico
{
    public class ViaCepServico
    {
        public static string EnderecoUrl = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscaEnderecoViaCep(string cep)
        {
            string NovoEnderecoUrl = string.Format(EnderecoUrl, cep);

            using (WebClient wc = new WebClient())
            {
                string Conteudo = wc.DownloadString(NovoEnderecoUrl);

                Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);
                
                return end;
            }
            
        }

    }
}
