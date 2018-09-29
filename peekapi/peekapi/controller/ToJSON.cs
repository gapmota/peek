using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft;
using Newtonsoft.Json;
using peekapi.models;

namespace peekapi.controller
{
    public class ToJSON
    {
        public string getUsuarioToJson()
        {
            return JsonConvert.SerializeObject(new EntidadeUsuario().getUsuarios());
        }

        public List<Usuario> JsonToListUsuario(string json)
        {
            return JsonConvert.DeserializeObject<List<Usuario>>(json);
        }

        public string getMemoriaToJson()
        {
            return JsonConvert.SerializeObject(new EntidadeMemoria().getMemoria());
        }

        public Memoria JsonToGetMemoria(string json)
        {
            return JsonConvert.DeserializeObject<Memoria>(json);
        } 


    }
}