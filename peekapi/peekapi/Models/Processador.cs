using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace peekapi.Models
{
    public class Processador
    {
        public int IdProcessador { get; set; }
        public string TempoAtividade { get; set; }
        public string DataCadastro { get; set; }
        public string PorcentagemUso { get; set; }
        public int IdComputador { get; set; }

    }
}