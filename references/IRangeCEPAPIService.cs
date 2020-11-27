using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace Consultar_CEP.references
{
    public interface IRangeCEPAPIService
    {
        [Get ("/app/faixa_cep_uf_localidade/carrega-faixa-cep-uf-localidade.php?letraLocalidade=&ufaux=&pagina=%2Fapp%2Ffaixa_cep_uf_localidade%2Findex.php&mensagem_alerta=&uf={uf}&localidade={city}&cepaux=]")]
        Task<RangeCEPResponse> GetRangeCEPAsync(string uf, string city);
    }
}
