using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace peekapi.Models
{
    public class Processo
    {
        public int IdProcesso { get; set; }
        public long TempoInicio { get; set; }
        public long OpenFiles { get; set; }
        public long TempoModoUsuario { get; set; }
        public long MemoriaRamUsada { get; set; }
        public long BytesLidos { get; set; }
        public long BytesEscritos { get; set; }
        public int Pid { get; set; }
        public int Prioridade { get; set; }
        public int IdComputador { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Grupo { get; set; }
        public string CommandLine { get; set; }
        public string DataCadastro { get; set; }
        public string Caminho { get; set; }
        public string GrupoID { get; set; }

       
    }

    public class ProcessosInternet
    {
        public string Nome { get; set; }
        public double MemoriRam { get; set; } 

        public int QuantidadeProcessosAberto { get; set; }
    }

}