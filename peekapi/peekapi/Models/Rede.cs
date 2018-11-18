using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace peekapi.Models
{
    public class Rede
    {
        public int IdRede { get; set; }
        public int IdComputador { get; set; }
        public string Ipv4 { get; set; }
        public string Ipv6 { get; set; }
        public string MacAddress { get; set; }
        public string VelocidadeDownload { get; set; }
        public string VelocidadeUpload { get; set; }
        public string DataCadastro { get; set; }

    }
}