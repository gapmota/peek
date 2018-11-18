using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace peekapi.Models
{
    public class Computador
    {
       
        public int IdComputador { get; set; }
        public string QuantidadeMemoriaRam { get; set; }
        public string DescricaoProcessador { get; set; }
        public string MacAddressInicial { get; set; }
        public int IdLab { get; set; }

        /*
        [JsonProperty(PropertyName = "id_computador")]
        public int IdComputador { get; set; }

        [JsonProperty(PropertyName = "quantidade_memoria_ram")]
        public string QuantidadeMemoriaRam { get; set; }

        [JsonProperty(PropertyName = "descricacao_processador")]
        public string DescricaoProcessador { get; set; }

        [JsonProperty(PropertyName = "mac_address_inicial")]
        public string MacAddressInicial { get; set; }

        [JsonProperty(PropertyName = "id_lab")]
        public int IdLab { get; set; }*/
    }
}