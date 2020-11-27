using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultar_CEP.references
{
    public class CEPResponse
    {
        public bool erro { get; set; }
        public string mensagem { get; set; }
        public int total { get; set; }
        public List<Dados> dados { get; set; }


        public class Dados
        {
            public string uf { get; set; }
            public string localidade { get; set; }
            public string localidadeSubordinada { get; set; }
            public string logradouroDNEC { get; set; }
            public string logradouroTextoAdicional { get; set; }
            public string logradouroTexto { get; set; }
            public string bairro { get; set; }
            public string nomeUnidade { get; set; }
            public string cep { get; set; }
            public string tipoCep { get; set; }
            public string numeroLocalidade { get; set; }
            public string situacao { get; set; }
            public List<object> faixasCaixaPostal { get; set; }
            public List<object> faixasCep { get; set; }
        }


    }
}
