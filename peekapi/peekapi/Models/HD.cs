using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace peekapi.Models
{
    public class HD
    {
        public int IdHd { get; set; }
        public string Total { get; set; }
        public string Usado { get; set; }
        public string Diretorio { get; set; }
        public string Uuid { get; set; }
        public string TipoDir { get; set; }
        public string Volume { get; set; }
        public int IdComputador { get; set; }
        public string DataCadastro { get; set; }

    }
}