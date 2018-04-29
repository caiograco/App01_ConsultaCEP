using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultaCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultaCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";


        //===================================================================
        // BuscarEnderecoViaCEP
        //-------------------------------------------------------------------
        // Busca endereco no Webservice ViaCEP, pelo cep digitado
        //===================================================================
        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.CEP == null) return null;

            return end;
        }
    }
}
