using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace peekapi.Models
{
    public class InfoComputador
    {

        public Computador Computador { get; set; }
        public List<HD> Hd { get; set; }
        public List<MacAddress> Macs { get; set; }
        public MemoriaRam MemoriaRam { get; set; }
        public Processador Processador { get; set; }
        public List<Processo> Processos { get; set; }
        public Rede Rede { get; set; }

    }
}