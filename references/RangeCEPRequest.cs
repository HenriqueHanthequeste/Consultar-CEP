using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultar_CEP.references
{
    class RangeCEPRequest
    {
        public RangeCEPResponse GetRangeCEPResponse(string uf, string localidade)
        {
            var client = new RestClient("https://buscacepinter.correios.com.br/app/faixa_cep_uf_localidade/carrega-faixa-cep-uf.php");

            client.Timeout = -1;
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.77 Safari/537.36";

            var request = new RestRequest(Method.POST);

            request.AddHeader("sec-ch-ua", "\" Not;A Brand\";v=\"99\", \"Google Chrome\";v=\"91\", \"Chromium\";v=\"91\"");
            request.AddHeader("Cache-Control", "no-store, no-cache, must-revalidate");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("content-type", "application/x-www-form-urlencoded; charset=UTF-8");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Cookie", "buscacep=20vpadlco4q98tbe7t3f8d2dml; cws-%3FEXTERNO_2%3Fpool_Proxy_reverso_cws_443=MOABKIMA");
            request.AddParameter("cepaux", "");
            request.AddParameter("letraLocalidade", $"{uf[0]}");
            request.AddParameter("localidade", $"{localidade}");
            request.AddParameter("mensagem_alerta", "");
            request.AddParameter("pagina", "/app/faixa_cep_uf_localidade/index.php");
            request.AddParameter("uf", $"{uf}");
            request.AddParameter("ufaux", "");

            IRestResponse response = client.Execute(request);

            RangeCEPResponse cEPResponse = JsonConvert.DeserializeObject<RangeCEPResponse>(response.Content);

            return cEPResponse;
        }
    }
}
