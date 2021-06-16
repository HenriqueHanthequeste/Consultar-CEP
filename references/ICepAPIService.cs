using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace Consultar_CEP.references
{
    public interface ICepAPIService
    {
        //[Get ("/app/endereco/carrega-cep-endereco.php?pagina=%2Fapp%2Fendereco%2Findex.php&cepaux=&mensagem_alerta=&endereco={cep}&tipoCEP=ALL")]
        [Get("/app/endereco/carrega-cep-endereco.php?pagina=%2Fapp%2Fendereco%2Findex.php&cepaux=&mensagem_alerta=&endereco={cep}&tipoCEP=ALL")]

        Task<CEPResponse> GetAddressAsync(string cep);
    }
}
