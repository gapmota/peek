using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace peekapi.Models
{
    public class MemoriaRam
    {
        public int IdMemoriaRam { get; set; }
        public double Total { get; set; }
        
        public double Livre { get; set; }
        public double EmUso { get; set; }
        public string DataCadastro { get; set; }
        public int IdComputador { get; set; }
        public int PorcentagemUso { get; set; }
    }
}