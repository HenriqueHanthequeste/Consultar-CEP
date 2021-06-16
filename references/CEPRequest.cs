using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Consultar_CEP.references
{
    class CEPRequest
    {
        public CEPResponse GetCEPResponse(string cep)
        {
            var client = new RestClient($"https://buscacepinter.correios.com.br/app/endereco/carrega-cep-endereco.php?cepaux=&endereco={cep}&mensagem_alerta=&pagina=%2Fapp%2Fendereco%2Findex.php&tipoCEP=ALL");
            client.Timeout = -1;
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.77 Safari/537.36";

            var request = new RestRequest(Method.POST);
            request.AddHeader("sec-ch-ua", "\" Not;A Brand\";v=\"99\", \"Google Chrome\";v=\"91\", \"Chromium\";v=\"91\"");
            request.AddHeader("Cache-Control", "no-store, no-cache, must-revalidate");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("content-type", "application/x-www-form-urlencoded; charset=UTF-8");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Cookie", "buscacep=20vpadlco4q98tbe7t3f8d2dml; cws-%3FEXTERNO_2%3Fpool_Proxy_reverso_cws_443=KPABKIMA");
            request.AddParameter("cepaux", "");
            request.AddParameter("endereco", $"{cep}");
            request.AddParameter("mensagem_alerta", "");
            request.AddParameter("pagina", "/app/endereco/index.php");
            request.AddParameter("tipoCEP", "ALL");

            IRestResponse response = client.Execute(request);

            CEPResponse cEPResponse = JsonConvert.DeserializeObject<CEPResponse>(response.Content);

            return cEPResponse;

            //Console.WriteLine(response.Content);
        }



        //        var client = new RestClient("https://buscacepinter.correios.com.br/app/endereco/carrega-cep-endereco.php?cepaux=&endereco=29172470&mensagem_alerta=&pagina=%2Fapp%2Fendereco%2Findex.php&tipoCEP=ALL");
        //        client.Timeout = -1;
        //var request = new RestRequest(Method.POST);
        //        request.AddHeader("sec-ch-ua", "\" Not;A Brand\";v=\"99\", \"Google Chrome\";v=\"91\", \"Chromium\";v=\"91\"");
        //request.AddHeader("Cache-Control", "no-store, no-cache, must-revalidate");
        //request.AddHeader("sec-ch-ua-mobile", "?0");
        //client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.77 Safari/537.36";
        //request.AddHeader("content-type", "application/x-www-form-urlencoded; charset=UTF-8");
        //request.AddHeader("Accept", "*/*");
        //request.AddHeader("Cookie", "buscacep=20vpadlco4q98tbe7t3f8d2dml; cws-%3FEXTERNO_2%3Fpool_Proxy_reverso_cws_443=KPABKIMA");
        //request.AddParameter("cepaux", "");
        //request.AddParameter("endereco", "29164008");
        //request.AddParameter("mensagem_alerta", "");
        //request.AddParameter("pagina", "/app/endereco/index.php");
        //request.AddParameter("tipoCEP", "ALL");
        //IRestResponse response = client.Execute(request);
        //        Console.WriteLine(response.Content);
    }
}
