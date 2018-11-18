using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace peekapi.Models
{
    public class FinalizarProcesso
    {
        public int IdFinalizarProcesso { get; set; }
        public int Pid { get; set; }
        public string NomeProcesso { get; set; }
        public bool Flag { get; set; }
        public int IdComputador { get; set; }
        public string DataCadastro { get; set; }
    }
}