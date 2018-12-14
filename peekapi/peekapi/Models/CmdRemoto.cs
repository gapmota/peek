using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace peekapi.Models
{
    public class CmdRemoto
    {
        public int IdCmdRemoto { get; set; }
        public string Comando { get; set; }
        public string Retorno { get; set; }
    }
}