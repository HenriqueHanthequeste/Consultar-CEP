using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultar_CEP.references
{
    public class RangeCEPResponse
    {
        public List<Dados> dados { get; set; }

        public class FaixasCep
        {
            public string cepInicial { get; set; }
            public string cepFinal { get; set; }
        }

        public class Dados
        {
            public List<FaixasCep> faixasCep { get; set; }
        }
    }
}
