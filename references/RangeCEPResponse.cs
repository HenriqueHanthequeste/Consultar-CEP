using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultar_CEP.references
{
    public class RangeCEPResponse
    {

        public bool erro { get; set; }
        public string mensagem { get; set; }
        public int total { get; set; }
        public List<Dados> dados { get; set; }

        public class FaixasCep
        {
            public string cepInicial { get; set; }
            public string cepFinal { get; set; }
            public string tipo { get; set; }
        }

        public class Dados
        {
            public List<FaixasCep> faixasCep { get; set; }
        }


    }
}
